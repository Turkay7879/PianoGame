using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
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
        //Application.Quit();   Uygulama built edildi�i zamanki ��k�� kodu
    }

    public void HowToPlay()
    {

    }

}
