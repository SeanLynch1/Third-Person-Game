using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public bool loadEasyGameOverScene;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Lava")
        {
            if(loadEasyGameOverScene)
            {
                SceneManager.LoadScene(5);
            }
            if(!loadEasyGameOverScene)
            {
                SceneManager.LoadScene(4);
            }
           
        }
    }

}
