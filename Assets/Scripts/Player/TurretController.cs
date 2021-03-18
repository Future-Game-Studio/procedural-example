using UnityEngine;
using FUGAS.Examples.Misc.Extensions;

namespace FUGAS.Examples.Player
{
    public class TurretController : MonoBehaviour
    {
        private ObjectPooler _objectPooler;
        private Transform _bulletRoot;
        private Rigidbody _parentRigidbody;
        private Animator _gunAnimator;

        void Awake()
        {
            _objectPooler = GetComponent<ObjectPooler>();
        }

        void Start()
        {
            _bulletRoot = this.gameObject.GetChildWithName("bullet_root").transform;
            _parentRigidbody = GetComponentInParent<Rigidbody>();
            _gunAnimator = this.gameObject.GetChildWithName("Mounted Gun").GetComponent<Animator>();
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.H))
            {
                Fire();
                _gunAnimator.SetTrigger("on_fire");
            }

            if (Input.GetKeyUp(KeyCode.V))
            {
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

                // set entry point as bullet root and enable on scene
                bullet.transform.parent = _bulletRoot.transform;
                bullet.SetActive(true);

                // configure exit event
                bullet.GetComponent<BulletController>().DisableOnDistance(this.transform.position, 30);

                // fire!
                bullet.GetComponentInChildren<Rigidbody>().AddForce(_bulletRoot.transform.forward * 100 + _parentRigidbody.velocity);

            }
            else
            {
                Debug.Log("Failed to configure bullet, pool returned null");
            }
        }
    }
}