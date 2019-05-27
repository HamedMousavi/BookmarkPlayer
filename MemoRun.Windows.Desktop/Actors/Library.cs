using Akka.Actor;
using MemoRun.Windows.Desktop.Actors.Commands;
using MemoRun.Windows.Desktop.Actors.Events;
using System.Collections.Generic;


namespace MemoRun.Windows.Desktop.Actors
{

    public class Library : ReceiveActor
    {

        private readonly List<Shelf> _library;
        private readonly Broadcaster _bc;

        public Library()
        {
            _library = new List<Shelf>();
            _bc = new Broadcaster();

            Receive<Add<Shelf>>(c =>
            {
                _library.Add(c.Item);
                _bc.Publish(new Added<Shelf>(c.Item));
            });

            //Receive<InformMe>(c =>
            //{
            //    _subscribers.Add(c.Subscriber);
            //});

            Receive<Inform>(c =>
            {
                _bc.Subscribe(c.Subscriber);
            });
        }


        //private void Publish<T>(Created<T> created)
        //{
        //    foreach (var actor in _subscribers)
        //    {
        //        actor.Tell(created);
        //    }
        //}


        #region Commands

        #endregion


        #region Events

        #endregion
    }


    public class Shelf
    {
        public Shelf(string title)
        {
            Title = title;
        }

        public string Title { get; }
    }
}
