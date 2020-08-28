using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace PlayerMovement
{

    public class TutorialLevel : MonoBehaviour
    {
        public float timer;
        public float timer2 = 0f;
        public PlayerBlendMovement control;
        public GameObject askPlayerToMove;
        public GameObject askPlayerToSprint;
        public GameObject askPlayerToJump;
        public GameObject askPlayerToHighJump;
        public GameObject highJumpCompleted;
        public GameObject beginIntroduction;

        public openDoor doorActivation;

        bool startTimer2 = false;
        bool jumpPressed = false;
        bool sprintPressed = false;

        bool switchTrigger = false;
        bool switchTriggerForJump = false;
        bool turnHighJumpOn = false;

        public Image tick;
        public Image fadeImage;

        public Image Pmove;
        public TextMeshProUGUI tellPlayertoMove;
        public Image Psprint;
        public TextMeshProUGUI tellPlayertoSprint;
        public Image Pjump;
        public TextMeshProUGUI tellPlayertoJump;
        public Image PHighJump;
        public TextMeshProUGUI tellPlayertoHighJump;

        public Image PMessage1;
        public TextMeshProUGUI message1;
        public Image PMessage2;
        public TextMeshProUGUI message2;
        public Image PMessage3;
        public TextMeshProUGUI message3;
        public Image PMessage4;
        public TextMeshProUGUI message4;
        public Image PMessage5;
        public TextMeshProUGUI message5;
        public Image PMessage6;
        public TextMeshProUGUI message6;
        // Start is called before the first frame update
        void Start()
        {
            beginIntroduction.SetActive(false);
            askPlayerToHighJump.SetActive(false);
            askPlayerToMove.SetActive(true);
            askPlayerToSprint.SetActive(false);
            askPlayerToJump.SetActive(false);
            tick.enabled = false;
            Pmove.enabled = false;
            tellPlayertoMove.enabled = false;
            Psprint.enabled = false;
            tellPlayertoSprint.enabled = false;
            Pjump.enabled = false;
            tellPlayertoJump.enabled = false;
            PHighJump.enabled = false;
            tellPlayertoHighJump.enabled = false;

            PMessage1.enabled = false;
            message1.enabled = false;
            PMessage2.enabled = false;
            message2.enabled = false;
            PMessage3.enabled = false;
            message3.enabled = false;
            PMessage4.enabled = false;
            message4.enabled = false;
            PMessage5.enabled = false;
            message5.enabled = false;
            PMessage6.enabled = false;
            message6.enabled = false;

            fadeImage.canvasRenderer.SetAlpha(1.0f);
            fadeImage.enabled = true;
            fadeImage.CrossFadeAlpha(0, 2, false);
         
        }

        // Update is called once per frame
        void Update()
        {
            if(control.Jump)
            {
                jumpPressed = true;
            }
            if(control.Sprinting)
            {
                sprintPressed = true;
            }

            if(switchTrigger)
            {
                askPlayerToSprint.SetActive(true);
            }
            else
            {
                askPlayerToSprint.SetActive(false);
            }
            if(switchTriggerForJump)
            {
                askPlayerToJump.SetActive(true);
            }
            else
            {
                askPlayerToJump.SetActive(false);
            }
            if(turnHighJumpOn)
            {
                askPlayerToHighJump.SetActive(true);
            }
            else
            {
                askPlayerToHighJump.SetActive(false);
            }

            if(startTimer2)
            {
                timer2 += Time.deltaTime;
                if (timer2 >= 6f)
                {
                    SceneManager.LoadScene(2);
                }
            }
        }


        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "AskPlayerToMove")
            {
                Pmove.enabled = true;
                tellPlayertoMove.enabled = true;
            }
            if (other.tag == "AskPlayerToMove" && control.Moving || other.tag == "AskPlayerToMove" && control.Sprinting || other.tag == "AskPlayerToMove" && Input.GetKey(KeyCode.LeftShift))
            {
                timer = timer + Time.deltaTime;
                if (timer >= 1f)
                {
                    tick.enabled = true;
                }
                if (timer >= 2f)
                {
                    timer = 0f;
                    askPlayerToMove.SetActive(false);
                    switchTrigger = true;
                    tick.enabled = false;
                    Pmove.enabled = false;
                    tellPlayertoMove.enabled = false;
                }
            }
            if (other.tag == "AskPlayerToSprint")
            {
                Psprint.enabled = true;
                tellPlayertoSprint.enabled = true;
            }
            if (other.tag == "AskPlayerToSprint" && sprintPressed)
            {
                timer = timer + Time.deltaTime;
                if (timer >= 1f)
                {
                    tick.enabled = true;
                }
                if (timer >= 2f)
                {
                    timer = 0f;
                    switchTriggerForJump = true;
                    switchTrigger = false;
                    askPlayerToSprint.SetActive(false);
                    tick.enabled = false;
                    Psprint.enabled = false;
                    tellPlayertoSprint.enabled = false;
                }
            }
            if (other.tag == "AskPlayerToJump")
            {
                Pjump.enabled = true;
                tellPlayertoJump.enabled = true;
            }
            if (other.tag == "AskPlayerToJump" && jumpPressed)
            {
                timer = timer + Time.deltaTime;
                if (timer >= 1f)
                {
                    tick.enabled = true;
                }
                if (timer >= 2f)
                {
                    timer = 0f;
                    switchTriggerForJump = false;
                    turnHighJumpOn = true;
                    askPlayerToJump.SetActive(false);
                    tick.enabled = false;
                    Pjump.enabled = false;
                    tellPlayertoJump.enabled = false;
                }
            }
            if (other.tag == "AskPlayerToHighJump")
            {
                PHighJump.enabled = true;
                tellPlayertoHighJump.enabled = true;
            }
            if (other.tag == "HighJumpComplete")
            {
                timer = timer + Time.deltaTime;
                if (timer >= 0.2f)
                {
                    tick.enabled = true;
                }
                if (timer >= 1f)
                {

                    askPlayerToHighJump.SetActive(false);
                    tick.enabled = false;
                    PHighJump.enabled = false;
                    tellPlayertoHighJump.enabled = false;
                    turnHighJumpOn = false;
                    timer = 0f;
                    highJumpCompleted.SetActive(false);
                    beginIntroduction.SetActive(true);

                }
            }
            if (other.tag == "Begin Introduction")
            {
                timer += Time.deltaTime;
                if (timer >= 0f)
                {
                    PMessage1.enabled = true;
                    message1.enabled = true;
                }
                if (timer >= 2f)
                {
                    message2.enabled = true;
                    PMessage2.enabled = true;
                    message1.enabled = false;
                    PMessage1.enabled = false;
                }
                if (timer >= 5f)
                {
                    PMessage3.enabled = true;
                    message3.enabled = true;
                    PMessage2.enabled = false; ;
                    message2.enabled = false;

                }
                if (timer >= 10f)
                {
                    PMessage3.enabled = false;
                    message3.enabled = false;
                    PMessage4.enabled = true;
                    message4.enabled = true;

                }
                if (timer >= 14f)
                {
                    PMessage4.enabled = false;
                    message4.enabled = false;
                    PMessage5.enabled = true;
                    message5.enabled = true;

                }
                if (timer >= 16f)
                {
                    PMessage5.enabled = false;
                    message5.enabled = false;
                    PMessage6.enabled = true;
                    message6.enabled = true;
                   // timer = 0f;
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "AskPlayerToHighJump")
            {
                turnHighJumpOn = false;
                
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Begin Introduction")
            {
                doorActivation.opening = true;
                
            }
            if(other.tag == "Begin Game")
            {
                fadeImage.CrossFadeAlpha(1, 2, false);
                startTimer2 = true;
             

            }

        }
    }
}
