using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public float TileSpeed = 5.00f;
    private float CreateDelay = 3.00f, CreateInterval = 1.00f;
    private bool CreatedTiles = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        GameObject Tiles1 = Instantiate(Tiles, new Vector3(spot, 5.8f, 0f) ,Quaternion.identity); //
        Tiles1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -TileSpeed);

    }
}
