using System;
using System.Collections.Generic;
using System.Linq;


namespace MemoRun.Windows.Desktop.Actors.Events
{

    public interface IEventSubscriber { }

    public interface IEventSubscriber<T> : IEventSubscriber
    {
        public void When(T e);
    }


    public class Broadcaster
    {

        private readonly Dictionary<Type, List<IEventSubscriber>> _subscribers;

        public Broadcaster()
        {
            _subscribers = new Dictionary<Type, List<IEventSubscriber>>();
        }


        public void Subscribe<T>(IEventSubscriber<T> subscriber)
        {
            var type = typeof(T);
            GetSubscriberSet(type).Add(subscriber);
        }


        public void Subscribe(object subscriber)
        {
            var subscriptionRequests =
                subscriber.GetType()
                    .GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventSubscriber<>));

            foreach (var subscriptionRequest in subscriptionRequests)
            {
                GetSubscriberSet(subscriptionRequest).Add((IEventSubscriber)subscriber);
            }
        }


        private List<IEventSubscriber> GetSubscriberSet(Type type)
        {
            if (!_subscribers.ContainsKey(type))
            {
                _subscribers.Add(type, new List<IEventSubscriber>());
            }

            return _subscribers[type];
        }

        public void Publish<T>(T e)
        {
            var type = typeof(IEventSubscriber<T>);
            if (_subscribers.ContainsKey(type))
            {
                var subscribers = _subscribers[type].OfType<IEventSubscriber<T>>();
                foreach (var subscriber in subscribers) {
                    subscriber.When(e);
                }
            }
        }
    }
}
