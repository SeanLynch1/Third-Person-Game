using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PlayerMovement
{
    public class LoadFinalScene : MonoBehaviour
    {
        public float timer2;
        public Image fadeImage;
        public bool startTimer2;
        public RaiseFloor raiseFloor;
    // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (startTimer2)
            {
                timer2 += Time.deltaTime;
                if (timer2 >= 6f)
                {
                    SceneManager.LoadScene(6);
                }
            }
        }
        private void OnCollisionEnter(Collision other)
        {

            if (other.gameObject.tag == "Player")
            {
         

                raiseFloor.moveFloorDown = true;


                gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                gameObject.GetComponent<Collider>().isTrigger = true;
                fadeImage.CrossFadeAlpha(1, 2, false);
                startTimer2 = true;

            }
        }
     
    }

}

