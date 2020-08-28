using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovement
{

    public class SpeedBoost : MonoBehaviour
    {
        public PlayerBlendMovement control;
        
        
        // Start is called before the first frame update
        void Start()
        {
          

        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnCollisionEnter(Collision other)
        {

            if (other.gameObject.tag == "Player")
            {
                control.sprintBoost = true;
                control.speedTimer = true;

                gameObject.GetComponent<Renderer>().material.color = Color.black;
                gameObject.GetComponent<Collider>().isTrigger = true;

            }

        }
        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.tag == "Player")
            {
                //control.sprintBoost = false;
                control.speedTimer = false;

              
            }
        }

    }
}
