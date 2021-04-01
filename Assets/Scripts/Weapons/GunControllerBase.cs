using UnityEngine;

namespace FUGAS.Examples.Player
{
    public class GunControllerBase : MonoBehaviour
    {
        private ObjectPooler _objectPooler;
        private Transform _bulletRoot;
        private Rigidbody _parentRigidbody;
        private Animator _gunAnimator;

        void Awake()
        {
            _objectPooler = this.gameObject.GetComponentInParent<ObjectPooler>();
        }

        void Start()
        {
            _bulletRoot = this.gameObject.transform;
            _parentRigidbody = GetComponentInParent<Rigidbody>();
            _gunAnimator = this.GetComponentInChildren<Animator>();
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.H))
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
                bullet.GetComponent<BulletController>().DisableOnDistance(_bulletRoot.transform.position, 15);

                // fire!
                bullet.GetComponentInChildren<Rigidbody>().AddForce(_bulletRoot.transform.forward * 900 + _parentRigidbody.velocity);

            }
            else
            {
                Debug.Log("Failed to configure bullet, pool returned null");
            }
        }
    }
}