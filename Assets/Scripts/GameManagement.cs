using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public float TileSpeed = 5.00f;
    private float CreateDelay = 3.00f, CreateInterval = 1.00f;
    private bool CreatedTiles = false;
    public int Lives = 3;
    public AudioSource[] sources;
    public AudioSource piano1;
    public AudioSource piano2;
    public AudioSource piano3;
    public AudioSource piano4;
    // Start is called before the first frame update
    void Start()
    {
        sources = new AudioSource[4];
        for (int i = 0; i < 4; i++)
        {
            sources[i] = GameObject.Find("Music" + ((i + 1).ToString())).GetComponent<AudioSource>();
        }
        piano1 = sources[0];
        piano2 = sources[1];
        piano3 = sources[2];
        piano4 = sources[3];
        int num = Random.Range(1, 5);
        if (num == 1)
        {
            piano1.Play();
        }
        else if (num == 2)
        {
            piano2.Play();
        }
        else if (num == 3)
        {
            piano3.Play();
        }
        else
        {
            piano4.Play();
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
        
    }

    public void CreateTiles()
    {   // spotlar Tile1,2,3,4 ün konumuna göre sabit. y kordinatý 5.8 de hepsinde sabit.
        float spot;
        int randomlane = Random.Range(1, 5);
        if (randomlane == 1) spot = -1.4787f;      //Tile1 x kordinat
        else if (randomlane == 2) spot = -0.5047f; //Tile2 x kordinat
        else if (randomlane == 3) spot = 0.4953f;  //Tile3 x kordinat
        else spot = 1.4687f;                       //Tile4 x kordinat
        GameObject Tiles = (GameObject)Resources.Load("Tile", typeof(GameObject));
        GameObject Tiles1 = Instantiate(Tiles, new Vector3(spot, 3.3f, 0f) ,Quaternion.identity); //
        Tiles1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -TileSpeed);

    }
}
