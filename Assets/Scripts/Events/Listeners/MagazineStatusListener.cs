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
            if (observableEvent is BulletReturnEvent bre)
            {
                _slider.value++;
            }

            if (observableEvent is GunFireEvent gfe)
            {
                _slider.maxValue = gfe.MagazineCapacity;
                _slider.value = gfe.Free;
            }
        }
    }
}
