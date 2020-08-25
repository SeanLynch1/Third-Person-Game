using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flashTimer : MonoBehaviour
{
    
    public Timer timer;

   
    // Start is called before the first frame update
    void Start()
    {
    
       
    }
    public void Update()
    {

    }
    // Update is called once per frame

    IEnumerator Blink()
    {
        while (true)
        {
            switch (timer.textDisplay.GetComponent<Text>().color.a.ToString())
            {
                case "0":
                    timer.textDisplay.GetComponent<Text>().color = new Color(timer.textDisplay.GetComponent<Text>().color.r, timer.textDisplay.GetComponent<Text>().color.g, timer.textDisplay.GetComponent<Text>().color.b, 0);
                    yield return new WaitForSeconds(5f);
                    break;
                case "1":
                    timer.textDisplay.GetComponent<Text>().color = new Color(timer.textDisplay.GetComponent<Text>().color.r, timer.textDisplay.GetComponent<Text>().color.g, timer.textDisplay.GetComponent<Text>().color.b, 1);
                    yield return new WaitForSeconds(5f);
                    break;
            }

        }
    }

    public void StartBlinking()
    {
      
        StartCoroutine("Blink");
 
    }
    public void StopBlinking()
    {
        StopCoroutine("Blink");
    }
}
