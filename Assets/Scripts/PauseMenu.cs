using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        SceneManager.LoadScene("PauseScene");
    }

    public void Continue()
    {

    }

    public void Replay()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Exit()
    {
        SceneManager.LoadScene("ExitScene");
    }

    public void ExitGame()
    {
        EditorApplication.isPlaying = false;
        //Application.Quit();   Uygulama built edildiði zamanki çýkýþ kodu
    }

}
