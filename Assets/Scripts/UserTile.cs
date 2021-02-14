using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserTile : MonoBehaviour
{
    Vector3 Tile1, Tile2, Tile3, Tile4;
    Vector3 CurrentPosition;

    // Start is called before the first frame update
    void Start()
    {
        Tile1 = GameObject.Find("Tile1").transform.position;
        Tile1.z = -1.1f;
        Tile2 = GameObject.Find("Tile2").transform.position;
        Tile2.z = -1.1f;
        Tile3 = GameObject.Find("Tile3").transform.position;
        Tile3.z = -1.1f;
        Tile4 = GameObject.Find("Tile4").transform.position;
        Tile4.z = -1.1f;

        int randomStart = Random.Range(1, 5);
        switch (randomStart) {
            case 1:
                GameObject.Find("Player").transform.position = Tile1;
                break;
            case 2:
                GameObject.Find("Player").transform.position = Tile2;
                break;
            case 3:
                GameObject.Find("Player").transform.position = Tile3;
                break;
            default:
                GameObject.Find("Player").transform.position = Tile4;
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    void Move()
    {
        GameObject Player = GameObject.Find("Player");
        CurrentPosition = Player.transform.position;

        if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && CurrentPosition != Tile1)
        {
            if (CurrentPosition == Tile2) Player.transform.position = Tile1;
            else if (CurrentPosition == Tile3) Player.transform.position = Tile2;
            else if (CurrentPosition == Tile4) Player.transform.position = Tile3;
        }

        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && CurrentPosition != Tile4)
        {
            if (CurrentPosition == Tile1) Player.transform.position = Tile2;
            else if (CurrentPosition == Tile2) Player.transform.position = Tile3;
            else if (CurrentPosition == Tile3) Player.transform.position = Tile4;
        }
    }
}
