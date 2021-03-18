using UnityEngine;

public class DisableBulletTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")){
            other.gameObject.SetActive(false);
        }
    }
}
