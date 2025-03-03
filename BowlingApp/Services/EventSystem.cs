using BowlingApp.Interfaces;

namespace BowlingApp.Services
{
    public class EventSystem
    {
        private readonly Dictionary<string, List<IObserver>> _observers = [];

        public void Subscribe(string eventType, IObserver observer)
        {
            if (!_observers.ContainsKey(eventType))
            {
                _observers[eventType] = [];
            }
            _observers[eventType].Add(observer);
        }

        public void Unsubscribe(string eventType, IObserver observer)
        {
            if (_observers.ContainsKey(eventType))
            {
                _observers[eventType].Remove(observer);
                if (_observers[eventType].Count == 0)
                {
                    _observers.Remove(eventType);
                }
            }
        }

        public void Notify(string eventType)
        {
            if (_observers.ContainsKey(eventType))
            {
                foreach (var observer in _observers[eventType])
                {
                    observer.OnEvent(eventType);
                }
            }
        }
    }
}
