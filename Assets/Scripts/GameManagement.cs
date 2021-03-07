using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagement : MonoBehaviour
{
    public float TileSpeed = 5.00f;
    private float CreateDelay = 3.00f, CreateInterval = 1.00f;
    private bool CreatedTiles = false;
    public int Lives = 3, Score = 0;

    public TMP_Text LifeText, ScoreText;
    public AudioSource[] sources = new AudioSource[4];
    private AudioSource currentMusic;
    public bool isPaused = false, PauseMusic = true;
    public GameObject canvas, bottomTiles, screenTiles;
    public static GameObject pauseCanvas;

    void Start()
    {
        int num = Random.Range(1, 5);
        switch(num)
        {
            case 1:
                sources[0].Play();
                currentMusic = sources[0];
                break;
            case 2:
                sources[1].Play();
                currentMusic = sources[1];
                break;
            case 3:
                sources[2].Play();
                currentMusic = sources[2];
                break;
            default:
                sources[3].Play();
                currentMusic = sources[3];
                break;
        }

        Time.timeScale = 1.0f;
        InvokeRepeating("IncreaseSpeed", 0f, 10f); // 10 saniyede bir hızlandır
    }

    void Update()
    {
        if (Lives == 0)
        {
            Time.timeScale = 0;
            currentMusic.Stop();
            CancelInvoke();
            int lastHighScore = PlayerPrefs.GetInt("HighScore");
            if (Score > lastHighScore)
            {
                PlayerPrefs.SetInt("HighScore", Score);
                PlayerPrefs.Save();
            }
            SceneManager.LoadScene("EndScene");
        }

        if (!CreatedTiles)
        {
            InvokeRepeating("CreateTiles", CreateDelay, CreateInterval);
            CreatedTiles = true;
        }

        if(isPaused == true)
        {
            Hide();
        }

        if (isPaused == false)
        {
            Show();
        }

    }

    public void CreateTiles()
    {  
        float spot;
        int randomlane = Random.Range(1, 5);
        int randomTile = Random.Range(1, 101);
        if (randomlane == 1) spot = -1.4787f;      //Tile1 x kordinat
        else if (randomlane == 2) spot = -0.5047f; //Tile2 x kordinat
        else if (randomlane == 3) spot = 0.4953f;  //Tile3 x kordinat
        else spot = 1.498f;                       //Tile4 x kordinat

        GameObject Tiles, Tiles1;
        if (randomTile < 10) // 10% şans, değiştirilebilir
        {
            Tiles = (GameObject)Resources.Load("Tiles\\StarTile", typeof(GameObject));
        }
        else if (randomTile > 85) // 15% şans, değiştirilebilir
        {
            Tiles = (GameObject)Resources.Load("Tiles\\BonusTile", typeof(GameObject));
        }
        else if (randomTile < 15) // 5% şans, değiştirilebilir
        {
            Tiles = (GameObject)Resources.Load("Tiles\\LifeTile", typeof(GameObject));
        }
        else
        {
            Tiles = (GameObject)Resources.Load("Tiles\\Tile", typeof(GameObject));
        }

        Tiles1 = Instantiate(Tiles, new Vector3(spot, 3.2f, -1f), Quaternion.identity);
        Tiles1.transform.parent = screenTiles.transform;
        Tiles1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -TileSpeed);

    }

    public void Hide()
    {
        pauseCanvas = GameObject.Find("PauseCanvas");
        canvas.SetActive(false);
        bottomTiles.SetActive(false);
        screenTiles.transform.localScale = new Vector3(0,0,0);

        if (PauseMusic)
        {
            currentMusic.Pause();
            PauseMusic = false;
        }
    }

    public void Show()
    {
        canvas.SetActive(true);
        bottomTiles.SetActive(true);
        screenTiles.transform.localScale = new Vector3(1.013592f, -3.855601f, -0.3281724f);
        if (!PauseMusic)
        {
            currentMusic.UnPause();
            PauseMusic = true;
        }
    }

    public void IncreaseSpeed() // Zorluk nasıl olacak değiştirilebilir
    {
        TileSpeed += 0.25f;
        // ...?
    }

}
