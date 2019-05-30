using Akka.Actor;
using MemoRun.Windows.Desktop.Actors.Commands;
using MemoRun.Windows.Desktop.Actors.Events;
using MemoRun.Windows.Desktop.Resources;
using System.Collections.Generic;

namespace MemoRun.Windows.Desktop.Actors
{

    public class LibraryDirector : ReceiveActor
    {

        private readonly Dictionary<string, IActorRef> _libraries = new Dictionary<string, IActorRef>();
        private readonly Broadcaster _bc = new Broadcaster();


        public LibraryDirector()
        {
            Receive<Add<Library>>(message =>
            {
                var libName = message.Item.Title;
                if (!_libraries.ContainsKey(libName))
                {
                    _libraries.Add(libName, Context.ActorOf<LibraryManager>());
                    _bc.Publish(new Added<Library>(message.Item));
                }
            });

            Receive<SendEventsTo>(c =>
            {
                _bc.Subscribe(c.Subscriber);
            });
        }


        #region Commands

        #endregion


        #region Events

        #endregion
    }
}
