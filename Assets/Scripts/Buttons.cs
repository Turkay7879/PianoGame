using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    GameManagement pauseManagement;
    public GameObject canvas;
    public GameObject parentCanvas;


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

    public void MainMenuExit()
    {
        parentCanvas = GameObject.Find("ParentCanvas").transform.Find("Canvas").gameObject;
        parentCanvas.SetActive(false);
        SceneManager.LoadScene("ExitScene", LoadSceneMode.Additive);
        //Application.Quit();   Uygulama built edildi?i zamanki ??k?? kodu
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
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

    public void goBack()
    {
        if (SceneManager.GetActiveScene().name.Equals("MainScene"))
        {
            canvas = GameObject.Find("ParentPause").transform.Find("PauseCanvas").gameObject;
            canvas.SetActive(true);
            SceneManager.UnloadSceneAsync("ExitScene");
        }

        else if (SceneManager.GetActiveScene().name.Equals("HowToPlay") || SceneManager.GetActiveScene().name.Equals("EndScene"))
        {
            SceneManager.LoadScene("MainMenu");
        }

        else if (SceneManager.GetActiveScene().name.Equals("MainMenu"))
        {
            parentCanvas = GameObject.Find("ParentCanvas").transform.Find("Canvas").gameObject;
            parentCanvas.SetActive(true);
            SceneManager.UnloadSceneAsync("ExitScene");
        }

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

    public void PauseMenuExit()
    {
        canvas = GameObject.Find("ParentPause").transform.Find("PauseCanvas").gameObject;
        //tempCanvas = canvas;
        canvas.SetActive(false);
        SceneManager.LoadScene("ExitScene", LoadSceneMode.Additive);
    }

}
