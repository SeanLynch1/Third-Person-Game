using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovement
{

    public class RotatingScript : MonoBehaviour
    {

        public float speed;
        public float pushForce;
        public bool PushLeft;

        public PlayerBlendMovement control;

        void Start()
        {
            control.GetComponent<PlayerBlendMovement>();
        }
        void FixedUpdate()
        {
            if (PushLeft)
            {
                transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
            }
            else
            {
                transform.Rotate(new Vector3(0, -speed * Time.deltaTime, 0));
            }
        }

         void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player" && PushLeft)
            {
                collision.rigidbody.AddForce(Vector3.up * pushForce);
            }
            else if (collision.gameObject.tag == "Player" && !PushLeft)
            {
                collision.rigidbody.AddForce(Vector3.up * pushForce);
            }

        }
    }
}
