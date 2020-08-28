using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartMessage : MonoBehaviour
{
    public float Timer;
    
    float noTime = 4f;
    
    public TextMeshProUGUI startText;
    // Start is called before the first frame update
    void Start()
    {
        Timer = noTime;
        startText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 3.5)
        {
            startText.enabled = true;
        }
        if (Timer <= 3.0)
        {
            startText.enabled = false;
        }
        if (Timer <= 2.5)
        {
            startText.enabled = true;
        }
        if (Timer <= 2)
        {
            startText.enabled = false;
        }
        if (Timer <= 1.5)
        {
            startText.enabled = true;
        }
        if (Timer <= 1)
        {
            startText.enabled = false;
        }
        if (Timer <= 0.5)
        {
            startText.enabled = true;
        }
        if (Timer <= 0)
        {
            startText.enabled = false;
        }






    }
}
