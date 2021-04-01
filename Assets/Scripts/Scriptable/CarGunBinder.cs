using FUGAS.Examples.Scripts;
using FUGAS.Examples.Scripts.Scriptable;
using UnityEngine;

namespace FUGAS.Examples
{
    public class CarGunBinder : MonoBehaviour
    {
        public GunData Data;
        private WeaponController _currentGun;
        private GunData[] _ourWeaponCollection;
        private int _selectedGunDataIndex = 1;

        private void Awake()
        {
            // for this example we just get all our weapons
            // to change them in loop
            _ourWeaponCollection = Resources.LoadAll<GunData>("ScriptableObjects/Guns");
            // set negative for nothing
            _selectedGunDataIndex = -1;
        }

        void Start()
        {
            SetGun();
        }

        private void SetGun()
        {
            // select asset
            if (_selectedGunDataIndex >= 0)
            {
                Data = _ourWeaponCollection[_selectedGunDataIndex];
            }

            // destroy everything we have
            if (_currentGun)
                Destroy(_currentGun.gameObject, 0);

            // set new data if available
            if (Data)
            {
                var pos = this.gameObject.transform.position;
                var rot = this.gameObject.transform.rotation;
                _currentGun = Instantiate(Data.Prefab, pos + Data.Prefab.transform.position,
                     rot * Data.Prefab.transform.rotation, this.gameObject.transform);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (++_selectedGunDataIndex == _ourWeaponCollection.Length)
                {
                    _selectedGunDataIndex = -1;
                    Data = null;
                }

                SetGun();
            }
        }
    }
}