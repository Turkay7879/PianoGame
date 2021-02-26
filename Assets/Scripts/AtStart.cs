using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AtStart : MonoBehaviour
{
    public TMP_Text HighScoreText;

    void Start()
    {
        HighScoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
            PlayerPrefs.Save();
        }

        int HighScore = PlayerPrefs.GetInt("HighScore");
        HighScoreText.text = "En Yüksek Skor: " + HighScore;
    }

    
    void Update()
    {
        
    }
}
