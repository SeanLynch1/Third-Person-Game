using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Image fadeOut;
    
    public float timer = 0f;

    private void Start()
    {
        fadeOut.enabled = true;
        fadeOut.canvasRenderer.SetAlpha(1.0f);
        fadeOut.CrossFadeAlpha(0, 3, false);
    }

    public void Update()
    {
    
    }
 
    public void PlayGameTutorialVersion()
    {
        fadeOut.CrossFadeAlpha(1, 2, false);
        
        SceneManager.LoadScene(1);

    }
    public void PlayGameEasyVersion()
    {
        SceneManager.LoadScene(2);
    }
    public void PlayGameHardVersion()
    {
        SceneManager.LoadScene(3);
    }
    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }
}
