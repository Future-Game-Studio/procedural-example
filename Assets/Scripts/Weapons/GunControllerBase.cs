using System;
using FUGAS.Examples.Events.Entities;
using FUGAS.Examples.Events.Observer;
using FUGAS.Examples.Events.Observer.Abstractions;
using UnityEngine;

namespace FUGAS.Examples.Player
{
    public class GunControllerBase : MonoBehaviour
    {
        private ObjectPooler _objectPooler;
        private Transform _bulletRoot;
        private Rigidbody _parentRigidbody;
        private Animator _gunAnimator;
        private FireSystemSubject _observer;
        private bool _isContinuousFire;

        void Awake()
        {
            _objectPooler = this.gameObject.GetComponentInParent<ObjectPooler>();
            _observer = FireSystemSubject.Instance;
        }

        void Start()
        {
            _bulletRoot = this.gameObject.transform;
            _parentRigidbody = GetComponentInParent<Rigidbody>();
            _gunAnimator = this.GetComponentInChildren<Animator>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                _isContinuousFire = true;
                var (freeBullets, magazineCapacity) = _objectPooler.GetAvailableCount("Bullet");
                _observer.Notify(new GunShootingStartedEvent(freeBullets, magazineCapacity));
            }

            if (Input.GetKeyUp(KeyCode.H))
            {
                _isContinuousFire = false;
                var (freeBullets, magazineCapacity) = _objectPooler.GetAvailableCount("Bullet");
                _observer.Notify(new GunShootingStoppedEvent(freeBullets, magazineCapacity));
            }

            if (_isContinuousFire)
            {
                Fire();
                if (_gunAnimator)
                    _gunAnimator.SetTrigger("on_fire");
            }

            if (Input.GetKeyUp(KeyCode.V))
            {
                if (_gunAnimator)
                    _gunAnimator.SetTrigger("on_idle");
            }
        }

        private void Fire()
        {
            var bullet = _objectPooler.GetPooledObject("Bullet");
            if (bullet)
            {
                // apply transformations before setting parent
                bullet.transform.SetPositionAndRotation(_bulletRoot.transform.position, _bulletRoot.transform.rotation);

                bullet.SetActive(true);

                // configure exit event
                bullet.GetComponent<BulletController>()
                .DisableOnDistance(_bulletRoot.transform.position, 40,
                    () =>
                    {
                        Debug.Log("We are in lambda function");
 
                        _observer.Notify(new BulletReturnEvent());
                    });

                // fire!
                bullet.GetComponentInChildren<Rigidbody>().AddForce(_bulletRoot.transform.forward * 900 + _parentRigidbody.velocity);

                var (freeBullets, magazineCapacity) = _objectPooler.GetAvailableCount("Bullet");
                _observer.Notify(new GunFireEvent(freeBullets, magazineCapacity));
            }
            else
            {
                _observer.Notify(new GunEmptyMagazineEvent());
                Debug.Log("Failed to configure bullet, pool returned null");
            }
        } 
    }
}