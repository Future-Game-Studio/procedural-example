using FUGAS.Examples.Events.Observer;
using UnityEngine;
using UnityEngine.UI;
using FUGAS.Examples.Misc;
using FUGAS.Examples.Events.Observer.Abstractions;
using FUGAS.Examples.Events.Entities;

namespace FUGAS.Examples.Events.Listeners
{
    public class ShootSerieListener : ShootEventListenerPanel
    {
        private void Start()
        {
            FireSystemSubject.Instance.AddObserver(this);

            _counterText = this.gameObject.GetChildWithName("ShootCounterValue").GetComponent<Text>();
        }

        public override void OnNotify(IObservableEvent observableEvent)
        {
            if (observableEvent is GunShootingStoppedEvent)
            {
                _statefullCounter = 0;
            }
            base.OnNotify(observableEvent);
        }
    }
}