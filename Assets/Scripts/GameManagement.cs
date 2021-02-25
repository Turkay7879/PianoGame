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
    public bool isPaused = false;
    public GameObject canvas, bottomTiles , screenTiles;

    // Start is called before the first frame update
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
            sources[i] = GameObject.Find("Music" + ((i + 1).ToString())).GetComponent<AudioSource>();
        }
        
        int num = Random.Range(1, 5);
        if (num == 1)
        {
            sources[0].Play();
        }
        else if (num == 2)
        {
            sources[1].Play();
        }
        else if (num == 3)
        {
            sources[2].Play();
        }
        else
        {
            sources[3].Play();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Lives == 0)
        {
            Time.timeScale = 0;
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
    {   // spotlar Tile1,2,3,4 ün konumuna göre sabit. y kordinatý 5.8 de hepsinde sabit.
        float spot;
        int randomlane = Random.Range(1, 5);
        if (randomlane == 1) spot = -1.4787f;      //Tile1 x kordinat
        else if (randomlane == 2) spot = -0.5047f; //Tile2 x kordinat
        else if (randomlane == 3) spot = 0.4953f;  //Tile3 x kordinat
        else spot = 1.498f;                       //Tile4 x kordinat
        GameObject Tiles = (GameObject)Resources.Load("Tiles\\Tile", typeof(GameObject));
        GameObject Tiles1 = Instantiate(Tiles, new Vector3(spot, 3.3f, -1f) ,Quaternion.identity);
        Tiles1.transform.parent = screenTiles.transform;
        Tiles1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -TileSpeed);
    }

    public void Hide()
    {
        canvas.SetActive(false);
        bottomTiles.SetActive(false);
        screenTiles.SetActive(false); //nesnenin içindeki düþen taþlar bu kodda yok ediliyo, düzelt
    }

    public void Show()
    {
        canvas.SetActive(true);
        bottomTiles.SetActive(true);
        screenTiles.SetActive(true);
    }

}
