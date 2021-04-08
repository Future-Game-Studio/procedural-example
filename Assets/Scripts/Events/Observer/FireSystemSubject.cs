using System.Collections.Generic;
using FUGAS.Examples.Events.Listeners;
using FUGAS.Examples.Events.Observer.Abstractions;
using UnityEngine;

namespace FUGAS.Examples.Events.Observer
{
    public class FireSystemSubject : MonoBehaviour
    {
        private List<IObserver> _observers = new List<IObserver>();
        public static FireSystemSubject Instance;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;

                this.AddObserver(new ConsoleMessageListener());
            }
        }

        public void Notify(IObservableEvent @event)
        {
            for (int i = 0; i < _observers.Count; i++)
            {
                _observers[i].OnNotify(@event);
            }
        }

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
        }
    }

}