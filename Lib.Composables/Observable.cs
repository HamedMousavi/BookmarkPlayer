using System;
using System.Collections.Generic;
using System.Linq;
using Lib.Composables.Abstract;


namespace Lib.Composables
{

    public class Observable : IComposableObservable
    {

        protected Dictionary<Type, IComposableNotifier> _observers;


        public void When<T>(Action<T> action)
        {
            if (_observers == null)
                _observers = new Dictionary<Type, IComposableNotifier>();

            var type = typeof(T);
            if (!_observers.ContainsKey(type))
                _observers.Add(type, new Notifier<T>());

            ((Notifier<T>)_observers[type]).Add(action);
        }


        protected void Notify<T>(T t)
        {
            var type = typeof(T);

            if (_observers != null)
                if (_observers.ContainsKey(type))
                    _observers[type].Notify(t);
        }
    }


    public class Notifier<T> : IComposableNotifier
    {

        protected ICollection<Action<T>> _observers;


        public void Add(Action<T> action)
        {
            if (_observers == null) _observers = new List<Action<T>>();
            _observers.Add(action);
        }


        public void Notify(object t)
        {
            _observers
                .AsParallel()
                .ForAll(o => o((T)t));
        }
    }
}
