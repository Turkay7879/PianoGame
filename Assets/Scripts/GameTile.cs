using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile : MonoBehaviour
{
    GameManagement management;
    SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        management = GameObject.Find("GameManagement").GetComponent<GameManagement>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name.Equals("Background"))
        {
            if (spriteRenderer.material.color != Color.green)
            {
                int live = management.Lives;
                live--;
                management.Lives = live;
            }
            
            Destroy(this.gameObject);
        }
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
        {
            spriteRenderer.material.SetColor("_Color", Color.green);
            
        }
         
    }
}
