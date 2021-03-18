using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FUGAS.Examples.Player
{
    public class PlayerController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        public int speed = 10;
        public int rotation = 10;

        // Update is called once per frame
        void Update()
        {
            var move = Input.GetAxis("Vertical") * speed;
            var rotate = Input.GetAxis("Horizontal") * rotation;
            move *= Time.deltaTime;
            rotate *= Time.deltaTime;
            transform.Translate(0, 0, move);
            transform.Rotate(0, rotate, 0);
        }
    }
}