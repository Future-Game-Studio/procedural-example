using FUGAS.Examples.Events.Observer;
using UnityEngine;
using UnityEngine.UI;
using FUGAS.Examples.Misc;
using FUGAS.Examples.Events.Observer.Abstractions;
using FUGAS.Examples.Events.Entities;

namespace FUGAS.Examples.Events.Listeners
{
    public class ShootEventListenerPanel : MonoBehaviour, IObserver
    {
        protected Text _counterText;
        protected int _statefullCounter = 1;

        private void Start()
        {
            FireSystemSubject.Instance.AddObserver(this);

            _counterText = this.gameObject.GetChildWithName("ShootCounterValue").GetComponent<Text>();
        }

        public virtual void OnNotify(IObservableEvent observableEvent)
        {
            if (observableEvent is GunFireEvent ev)
            {
                _counterText.text = (_statefullCounter++).ToString();
            }
        }
    }
}