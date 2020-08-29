using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMenu : MonoBehaviour
{
    public Image fadeIn;
    // Start is called before the first frame update
    void Start()
    {
        fadeIn.CrossFadeAlpha(0, 3, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
