using FUGAS.Examples.Events.Entities;
using FUGAS.Examples.Events.Observer;
using FUGAS.Examples.Events.Observer.Abstractions;
using FUGAS.Examples.Misc;
using UnityEngine;
using UnityEngine.UI;

namespace FUGAS.Examples.Events.Listeners
{

    public class MagazineStatusListener : MonoBehaviour, IObserver
    {
        private Slider _slider;
        private int _globalShootCounter;

        private void Start()
        {
            FireSystemSubject.Instance.AddObserver(this);

            _slider = this.gameObject.GetChildWithName("SliderBar").GetComponent<Slider>();
        }

        public void OnNotify(IObservableEvent observableEvent)
        {
            if (observableEvent is GunFireEvent ev)
            {
                _slider.maxValue = ev.MagazineCapacity;
                _slider.value = ev.Free;
            }
        }
    }
}
