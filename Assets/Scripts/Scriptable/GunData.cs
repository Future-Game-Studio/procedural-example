using UnityEngine;

namespace FUGAS.Examples.Scripts.Scriptable
{
    [CreateAssetMenu(fileName = "New Gun",
        menuName = "Game Store/Gun")]
    public class GunData : ScriptableObject
    {
        public WeaponController Prefab;
        public int FirePoints;
        public int Damage;
        public int Cost;
        public bool Locked = true;
    }

}