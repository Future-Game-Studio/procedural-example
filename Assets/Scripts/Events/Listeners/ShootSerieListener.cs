using FUGAS.Examples.Events.Observer; 
using UnityEngine.UI;
using FUGAS.Examples.Misc;
using FUGAS.Examples.Events.Observer.Abstractions;
using FUGAS.Examples.Events.Entities;

namespace FUGAS.Examples.Events.Listeners
{
    public class ShootSerieListener : ShootEventListenerPanel
    { 
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