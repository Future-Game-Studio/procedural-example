using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        var d = Vector3.Distance(_from, _rigidbody.position);
        if (d > _targetUnits)
        {
            this.gameObject.SetActive(false);
        }
    }
    public void DisableOnDistance(Vector3 from, float units)
    {
        _from = from;
        _targetUnits = units;
    }
}
