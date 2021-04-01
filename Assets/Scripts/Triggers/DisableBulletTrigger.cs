using UnityEngine;

namespace FUGAS.Examples.Player
{
    public class DisableBulletTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("BulletCollider"))
            {
                other.GetComponentInParent<BulletController>().OnCollision();
            }
        }
    }
}
