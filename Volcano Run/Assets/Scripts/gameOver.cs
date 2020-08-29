using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public bool loadEasyScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Retry()
    {
        if(loadEasyScene)
        {
            SceneManager.LoadScene(2);
        }
        if(!loadEasyScene)
        {
            SceneManager.LoadScene(3);
        }
       
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene(0);
    }
}
