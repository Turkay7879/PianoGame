using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    public float TileSpeed = 5.00f;
    private float CreateDelay = 3.00f, CreateInterval = 1.00f;
    private bool CreatedTiles = false;
    public int Lives = 3;
    public Text LifeText;
    public int Score =0;
    public Text ScoreText;
    public AudioSource[] sources;
    private AudioSource currentMusic;
    public bool isPaused = false, PauseMusic = true;
    public GameObject canvas, bottomTiles, screenTiles;

    void Start()
    {   
        canvas = GameObject.Find("MainCanvas");
        bottomTiles = GameObject.Find("BottomTiles");
        screenTiles = GameObject.Find("ScreenTiles");
        LifeText = GameObject.Find("LifeText").GetComponent<Text>();
        LifeText.text = ": " + Lives.ToString();
        ScoreText = GameObject.Find("ScoreText").GetComponent <Text>();
        ScoreText.text = ": " + Score.ToString();

        sources = new AudioSource[4];
        for (int i = 0; i < 4; i++)
        {
            sources[i] = GameObject.Find("Music" + (i + 1).ToString()).GetComponent<AudioSource>();
        }
        
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

        InvokeRepeating("IncreaseSpeed", 0f, 10f); // 10 saniyede bir hızlandır
    }

    void Update()
    {
        if (Lives == 0)
        {
            Time.timeScale = 0;
            currentMusic.Stop();
            int lastHighScore = PlayerPrefs.GetInt("HighScore");
            if (Score > lastHighScore)
            {
                PlayerPrefs.SetInt("HighScore", Score);
                PlayerPrefs.Save();
            }
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
            
        }
        else if (randomTile < 15) // 15% şans, değiştirilebilir
        {
            
        }
        //   ... gibi gibi, şansa göre kullanılacak tile prefabı değişecek

        Tiles = (GameObject)Resources.Load("Tiles\\Tile", typeof(GameObject));
        Tiles1 = Instantiate(Tiles, new Vector3(spot, 3.3f, -1f), Quaternion.identity);
        Tiles1.transform.parent = screenTiles.transform;
        Tiles1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -TileSpeed);
    }

    public void Hide()
    {
        canvas.SetActive(false);
        bottomTiles.SetActive(false);
        screenTiles.SetActive(false); //nesnenin i?indeki d??en ta?lar bu kodda yok ediliyo, d?zelt
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
        screenTiles.SetActive(true);
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
