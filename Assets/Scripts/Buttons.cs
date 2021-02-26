using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    GameManagement pauseManagement;

    void Start()
    {
       
    }

    void Update()
    {

    }

    public void StartButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ExitButton()
    {
        EditorApplication.isPlaying = false;
        //Application.Quit();   Uygulama built edildi?i zamanki ??k?? kodu
    }

    public void HowToPlay()
    {

    }

    public void Pause()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
        pauseManagement = GameObject.Find("GameManagement").GetComponent<GameManagement>();
        pauseManagement.isPaused = true;
    }

    public void Replay()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainScene");
    }

    public void Exit()
    {
        SceneManager.LoadScene("ExitScene");
    }

    public void ExitGame()
    {
        EditorApplication.isPlaying = false;
        //Application.Quit();   Uygulama built edildi?i zamanki ??k?? kodu
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.UnloadSceneAsync("PauseScene");
        pauseManagement = GameObject.Find("GameManagement").GetComponent<GameManagement>();
        pauseManagement.isPaused = false;
    }

}
