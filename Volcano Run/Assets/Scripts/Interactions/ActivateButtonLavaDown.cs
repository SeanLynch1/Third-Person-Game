using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMovement
{

    public class ActivateButtonLavaDown : MonoBehaviour
    {
        public bool resetTimer;
        public Timer timer;
        public RaiseFloor raiseFloor;
        // Start is called before the first frame update
        void Start()
        {
            resetTimer = false;
            this.gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnCollisionEnter(Collision other)
        {

            if (other.gameObject.tag == "Player")
            {
                resetTimer = true;
                timer.useEventTimer = true;
                timer.lowerLavaLevels = true;
                raiseFloor.moveFloorUp = false;
                gameObject.GetComponent<Renderer>().material.color = Color.cyan;
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
