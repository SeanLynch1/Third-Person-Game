using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerMovement
{

    public class Timer : MonoBehaviour
    {
        public PlayerBlendMovement control;

        public Image FadeIn;
        public GameObject textDisplay;
        public Image whiteArrow;
        public Image yellowArrow;
        public Image whiteArrowDown;
        public Image yellowArrowDown;
        public Text lavaRising;
        public Text lavaSinking;
        public Image panel;
        private float startingTime;
        public float totalTime;

        public float timer2 = 0f;
        private float seconds;


        public bool speedUI = false;
        public Image speedBoost;
        public Text speedPercentage;
        public Image speedPanel;

        public bool useEventTimer = true;
        public bool lowerLavaLevels = false;
       

        public ActivateButtonLavaDown[] activateButtonLavaDown;
        public ActivateButton[] activateButton;
        

        public RaiseFloor raiseFloor;
        // Start is called before the first frame update

        void Start()
        {
            panel.enabled = false;
            startingTime = totalTime;
            whiteArrow.enabled = false;
            yellowArrow.enabled = false;
            whiteArrowDown.enabled = false;
            yellowArrowDown.enabled = false;
            lavaSinking.enabled = false;
            lavaRising.enabled = false;
            speedBoost.enabled = false;
            speedPercentage.enabled = false;

            FadeIn.canvasRenderer.SetAlpha(1.0f);
            FadeIn.enabled = true;
            FadeIn.CrossFadeAlpha(0, 4f, false);
        }


        // Update is called once per frame
        void Update()
        {
            totalTime -= Time.deltaTime;

            seconds = (int)(totalTime % 60);

            if (useEventTimer)
            {
                raiseFloor.moveFloorUp = false;

                if (seconds <= 0)
                {
                    totalTime = startingTime; //total time = 11
                    useEventTimer = false;
                }
                if (lowerLavaLevels)
                {
                    raiseFloor.moveFloorDown = true;

                }
            }
            if (!useEventTimer)
            {
                totalTime = 0f;
                raiseFloor.moveFloorDown = false;
                raiseFloor.moveFloorUp = true;
                //control.sprintBoost = false;
              
          
                
            }
            if (totalTime <= 0f)
            {
                textDisplay.GetComponent<Text>().color = Color.red;
                panel.enabled = true;
                lavaRising.enabled = true;
                yellowArrow.enabled = true;
                whiteArrow.enabled = false;
                timer2 = timer2 + Time.deltaTime;
                if (timer2 >= 0.25)
                {

                    yellowArrow.enabled = false;
                    whiteArrow.enabled = true;
                    textDisplay.GetComponent<Text>().enabled = true;
                }
                if (timer2 >= 0.5)
                {

                    whiteArrow.enabled = false;
                    yellowArrow.enabled = true;
                    textDisplay.GetComponent<Text>().enabled = false;
                    timer2 = 0;
                }

            }
            if (totalTime > 0f)
            {
                panel.enabled = false;
                lavaRising.enabled = false;
                yellowArrow.enabled = false;
                whiteArrow.enabled = false;
                textDisplay.GetComponent<Text>().color = Color.black;
                textDisplay.GetComponent<Text>().enabled = true;
            }
            if (raiseFloor.moveFloorDown)
            {
                textDisplay.GetComponent<Text>().color = Color.blue;

                panel.enabled = true;
                lavaSinking.enabled = true;
                lavaSinking.GetComponent<Text>().color = Color.blue;
                yellowArrowDown.enabled = true;
                whiteArrowDown.enabled = false;
                timer2 = timer2 + Time.deltaTime;
                if (timer2 >= 0.25)
                {

                    yellowArrowDown.enabled = false;
                    whiteArrowDown.enabled = true;
                    // textDisplay.GetComponent<Text>().enabled = true;
                }
                if (timer2 >= 0.5)
                {

                    whiteArrowDown.enabled = false;
                    yellowArrowDown.enabled = true;
                    //  textDisplay.GetComponent<Text>().enabled = false;
                    timer2 = 0;
                }
            }
            else
            {
                whiteArrowDown.enabled = false;
                yellowArrowDown.enabled = false;
                lavaSinking.enabled = false;
                lavaSinking.GetComponent<Text>().color = Color.red;
                //  panel.enabled = true;

            }

            if(speedUI)
            {
                speedPercentage.enabled = true;
                speedPanel.enabled = true;
                speedBoost.enabled = true;
            }
            else if(!speedUI)
            {
                speedPercentage.enabled = false;
                speedPanel.enabled = false;
                speedBoost.enabled = false;
            }
         

            if (activateButton[0].resetTimer)
            {
                useEventTimer = true;
             
                totalTime = 11f;
            }
            if (activateButton[1].resetTimer)
            {
                useEventTimer = true;
              
                totalTime = 11f;
            }
            if (activateButton[2].resetTimer)
            {
                useEventTimer = true;
              
                totalTime = 11f;
            }
            if (activateButton[3].resetTimer)
            {
                useEventTimer = true;
             
                totalTime = 11f;
            }
            if (activateButton[4].resetTimer)
            {
                useEventTimer = true;
               
                totalTime = 11f;
            }
            if (activateButton[5].resetTimer)
            {
                useEventTimer = true;
                
                totalTime = 11f;
            }
            if (activateButton[6].resetTimer)
            {
                useEventTimer = true;
               
                totalTime = 11f;
            }
            if (activateButton[7].resetTimer)
            {
                useEventTimer = true;

                totalTime = 11f;
            }
            if (activateButton[8].resetTimer)
            {
                useEventTimer = true;

                totalTime = 11f;
            }
            if (activateButton[9].resetTimer)
            {
                useEventTimer = true;

                totalTime = 11f;
            }
            if (activateButton[10].resetTimer)
            {
                useEventTimer = true;

                totalTime = 11f;
            }
            if (activateButton[11].resetTimer)
            {
                useEventTimer = true;

                totalTime = 11f;
            }
            if (activateButton[12].resetTimer)
            {
                useEventTimer = true;

                totalTime = 11f;
            }
            if (activateButton[13].resetTimer)
            {
                useEventTimer = true;

                totalTime = 11f;
            }
            //SINK LAVA BUTTONS
            if (activateButtonLavaDown[0].resetTimer)
            {
                useEventTimer = true;
                
                totalTime = 11f;
            }
            if (activateButtonLavaDown[1].resetTimer)
            {
                useEventTimer = true;
                
                totalTime = 11f;
            }
            if (activateButtonLavaDown[2].resetTimer)
            {
                useEventTimer = true;

                totalTime = 11f;
            }
            if (activateButtonLavaDown[3].resetTimer)
            {
                useEventTimer = true;

                totalTime = 11f;
            }
            if (activateButtonLavaDown[4].resetTimer)
            {
                useEventTimer = true;

                totalTime = 11f;
            }
            if (activateButtonLavaDown[5].resetTimer)
            {
                useEventTimer = true;

                totalTime = 11f;
            }


            textDisplay.GetComponent<Text>().text = "00:" + seconds.ToString();
        }

    }
}
