using FUGAS.Examples.Misc;
using FUGAS.Examples.Player;
using UnityEngine;

namespace FUGAS.Examples.Scripts
{
    public class WeaponController : MonoBehaviour
    { 
        void Start()
        {
            var roots = this.gameObject.GetChildsWithName("bullet_root");

            foreach (var root in roots)
            {
                root.AddComponent<GunControllerBase>();
            }
        }
 
        void Update()
        {

        }
    }
}