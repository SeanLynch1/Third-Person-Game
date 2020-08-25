using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;


public class Timer : MonoBehaviour
{
    public GameObject textDisplay;
    public Image whiteArrow;
    public Image yellowArrow;
    public Text lavaRising;

    private float startingTime;
    public float totalTime;

    public float timer2 = 0f;
    private float seconds;

    public bool useEventTimer = true;

    public flashTimer ft;

    public ActivateButton[] activateButton;
    public RaiseFloor raiseFloor;
    // Start is called before the first frame update

    void Start()
    {
        startingTime = totalTime;
        whiteArrow.enabled = false;
        yellowArrow.enabled = false;
        lavaRising.enabled = false;
    }

    
    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;

        seconds = (int)(totalTime % 60);

        if (useEventTimer)
        {
            raiseFloor.moveFloor = false;
           
            if (seconds <= 0 )
            {
                totalTime = startingTime; //total time = 11
                useEventTimer = false;
            }
       
        }
        if(!useEventTimer)
        {
            raiseFloor.moveFloor = true;
            totalTime = 0f;
         
            useEventTimer = true;
        
        }
        if(totalTime <= 0f)
        {
            textDisplay.GetComponent<Text>().color = Color.red;
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
        if(totalTime > 0f)
        {
            lavaRising.enabled = false;
            yellowArrow.enabled = false;
            whiteArrow.enabled = false;
            textDisplay.GetComponent<Text>().color = Color.black;
            textDisplay.GetComponent<Text>().enabled = true;
        }
     
        if(activateButton[0].resetTimer)
        {
            totalTime = 11f;
        }
        if (activateButton[1].resetTimer)
        {
            totalTime = 11f;
        }
        if (activateButton[2].resetTimer)
        {
            totalTime = 11f;
        }
        if (activateButton[3].resetTimer)
        {
            totalTime = 11f;
        }
        if (activateButton[4].resetTimer)
        {
            totalTime = 11f;
        }
        if (activateButton[5].resetTimer)
        {
            totalTime = 11f;
        }

     
        textDisplay.GetComponent<Text>().text = "00:" + seconds.ToString();
    }

}
