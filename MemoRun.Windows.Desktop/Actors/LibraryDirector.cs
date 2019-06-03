using Akka.Actor;
using MemoRun.Windows.Desktop.Actors.Commands;
using MemoRun.Windows.Desktop.Actors.Events;
using MemoRun.Windows.Desktop.Resources;
using System.Collections.Generic;
using System.Linq;


namespace MemoRun.Windows.Desktop.Actors
{

    public class LibraryDirector : AutoSnapshotActor
    {

        public LibraryDirector()
        {
            EnableEventStore<Add<Library>>(
                e => OnLibraryAdded(e.Item), 
                e => OnLibraryAdded(e.Item));

            EnableSnapshot<IEnumerable<string>>(
                new EventCountPersistPolocy(5), 
                _persistSerializer, 
                GetSnapshot, 
                SetSnapshot);

            Command<SendEvents>(message => RegisterSubscriber(message));
        }


        private void OnLibraryAdded(Library library)
        {
            _libraries.Add(library);
            _children.Add(Context.ActorOf(Props.Create(() => new LibraryManager(library))));
            _bc.Publish(new Added<Library>(library));
        }


        private object GetSnapshot()
        {
            return _libraries.Select(lib => lib.Title).ToArray();
        }


        private void SetSnapshot(IEnumerable<string> titles)
        {
            foreach (var title in titles)
            {
                OnLibraryAdded(new Library(title));
            }
        }


        private void RegisterSubscriber(SendEvents subscription)
        {
            _bc.Subscribe(subscription.Subscriber);
            if (subscription.SyncPolocy == SynchronizationPolocy.SendArchivedMessages)
            {
                foreach (var lib in _libraries)
                {
                    _bc.Publish(new Added<Library>(lib));
                }
            }
        }


        protected override string GetPersistId()
        {
            return "LibraryDirector";
        }


        private readonly List<IActorRef> _children = new List<IActorRef>();
        private readonly List<Library> _libraries = new List<Library>();
        private readonly Broadcaster _bc = new Broadcaster();
        private readonly IPersistSerializer _persistSerializer = new JsonPersistSerializer();


        #region Commands

        #endregion


        #region Events

        #endregion
    }
}
