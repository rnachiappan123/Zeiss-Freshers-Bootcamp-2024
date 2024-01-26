using System;
using System.Collections.Generic;

namespace DoorEventAggregator
{
    public class EventAggregator
    {
        public static readonly EventAggregator Instance;
        static EventAggregator()
        {
            Instance = new EventAggregator();
        }
        private EventAggregator() { }

        private Dictionary<Type, List<Action<object>>> subscribers = new Dictionary<Type, List<Action<object>>>();
        public void Subscribe<TEventType>(Action<object> handler)
        {
            Type eventType = typeof(TEventType);
            if (!subscribers.ContainsKey(eventType))
            {
                subscribers[eventType] = new List<Action<object>>();
            }
            subscribers[eventType].Add(handler);
        }
        public void Publish<TEventType>(object sender, TEventType eventArgs)
        {
            Type eventType = typeof(TEventType);
            if (subscribers.ContainsKey(eventType))
            {
                foreach (Action<object> subscriber in subscribers[eventType])
                {
                    subscriber.Invoke(eventArgs);
                }
            }
        }
    }
}
