using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource buttonSound;
    public void StartGame()
    {
        buttonSound.Play();
        SceneManager.LoadScene("LoadingGame");
    }
    public void ExitGame() 
    {
        buttonSound.Play();
        Application.Quit();
    }

    
}
