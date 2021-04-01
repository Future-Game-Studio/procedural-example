using UnityEngine;

namespace FUGAS.Examples.Player
{
    public class BulletController : MonoBehaviour
    {
        private Vector3 _from;
        private float _targetUnits;
        private Rigidbody _rigidbody;

        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponentInChildren<Rigidbody>();
        }

        internal void OnCollision()
        {
            ResetTransforms();
        }

        private void ResetTransforms()
        {
            this.gameObject.SetActive(false);

            // this will reset physical position of collider 
            _rigidbody.gameObject.transform.position = this.transform.position;
            _rigidbody.velocity = Vector3.zero;
        }

        // Update is called once per frame
        void Update()
        {
            var d = Vector3.Distance(_from, _rigidbody.position);
            if (d > _targetUnits)
            {
                ResetTransforms();
            }
        }

        public void DisableOnDistance(Vector3 from, float units)
        {
            _from = from;
            _targetUnits = units;
        }
    }
}
