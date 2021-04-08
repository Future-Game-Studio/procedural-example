using FUGAS.Examples.Events.Observer.Abstractions;
using UnityEditor;
using UnityEngine;

namespace FUGAS.Examples.Events.Listeners
{
    public class ConsoleMessageListener : IObserver
    {
        public void OnNotify(IObservableEvent observableEvent)
        {
            Debug.Log(observableEvent.GetType().Name + ": " + observableEvent.Message);
        }
    }
}
