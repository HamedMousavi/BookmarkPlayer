using Akka.Actor;
using Akka.Persistence;
using MemoRun.Windows.Desktop.Actors.Commands;
using MemoRun.Windows.Desktop.Actors.Events;
using MemoRun.Windows.Desktop.Resources;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json.Serialization;


namespace MemoRun.Windows.Desktop.Actors
{

    public class LibraryDirector : ReceivePersistentActor
    {

        public override string PersistenceId => "LibraryDirector";


        public LibraryDirector()
        {
            Command<Add<Library>>(message => AddLibrary(message.Item));
            Command<SendEvents>(message => RegisterSubscriber(message));

            Recover<Added<Library>>(message => OnLibraryAdded(message.Item));
            Recover<SnapshotOffer>(offer => OnLibrariesAdded(Deserialize(offer.Snapshot)));
        }


        private void RegisterSubscriber(SendEvents subscription)
        {
            _bc.Subscribe(subscription.Subscriber);
            if (subscription.SyncPolocy == SynchronizationPolocy.SendArchivedMessages)
            {
                foreach (var lib in _libraryNames)
                {
                    _bc.Publish(new Added<Library>(lib));
                }
            }
        }


        protected override bool Receive(object message)
        {
            return base.Receive(message);
        }


        private void OnLibrariesAdded(IEnumerable<string> titles)
        {
            foreach (var title in titles)
            {
                OnLibraryAdded(new Library(title));
            }
        }


        private void AddLibrary(Library library)
        {
            var e = new Added<Library>(library.Title);
            Persist(e, added =>
            {
                OnLibraryAdded(added.Item);
                if (ShouldTakeSnapshot()) TakeSnapshot();
            });
        }


        private void OnLibraryAdded(Library library)
        {
            _libraryNames.Add(library.Title);
            _libraries.Add(Context.ActorOf(Props.Create(() => new LibraryManager(library.Title))));
            _bc.Publish(new Added<Library>(library));
        }


        private bool ShouldTakeSnapshot()
        {
            return _eventCount++ > 5;
        }


        private void TakeSnapshot()
        {
            _eventCount = 0;
            SaveSnapshot(Serialize(_libraryNames.ToArray()));
        }


        private object Serialize(string[] libraryNames)
        {
            return JsonSerializer.ToString(libraryNames);
        }


        private IEnumerable<string> Deserialize(object snapshot)
        {
            return JsonSerializer.Parse<IEnumerable<string>>((string)snapshot);
        }


        protected override void PostStop()
        {
            Debug.WriteLine(">> Library Director Stopped!!");
            base.PostStop();
        }


        private readonly List<IActorRef> _libraries = new List<IActorRef>();
        private readonly List<string> _libraryNames = new List<string>();
        private readonly Broadcaster _bc = new Broadcaster();
        private int _eventCount;


        #region Commands

        #endregion


        #region Events

        #endregion
    }
}
