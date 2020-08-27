using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovement
{

    public class ActivateButton : MonoBehaviour
    {
        public bool resetTimer;

        public Timer timer;
        public RaiseFloor raiseFloor;

        // Start is called before the first frame update
        void Start()
        {

            resetTimer = false;
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnCollisionEnter(Collision other)
        {

            if (other.gameObject.tag == "Player")
            {
                timer.lowerLavaLevels = false;
                resetTimer = true;

                raiseFloor.moveFloorDown = false;
                timer.useEventTimer = true;

                gameObject.GetComponent<Renderer>().material.color = Color.blue;
                gameObject.GetComponent<Collider>().isTrigger = true;

            }

        }
        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.tag == "Player")
            {
                resetTimer = false;
                // timer.useEventTimer = false;

            }
        }
    }
}
  

