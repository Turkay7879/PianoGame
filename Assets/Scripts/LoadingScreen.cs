using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(LoadAsyncOperation());
    }

   
    IEnumerator LoadAsyncOperation()
    {
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync("MainScene");

        while (gameLevel.progress < 1)
        {
            yield return new WaitForEndOfFrame();
        }
    }
}
