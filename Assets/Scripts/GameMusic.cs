using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public AudioSource [] sources;
    public AudioSource piano1;
    public AudioSource piano2;
    public AudioSource piano3;
    public AudioSource piano4;
    // Start is called before the first frame update
    void Start()
    {
        sources = new AudioSource[4];
        for (int i = 0; i < 4; i++){
            sources[i] = GameObject.Find("Music" + ((i+1).ToString())).GetComponent<AudioSource>();
        }
        piano1 = sources[0];
        piano2 = sources[1];
        piano3 = sources[2];
        piano4 = sources[3];
        int num = Random.Range(1, 5);
        if(num == 1)
        {
            piano1.Play();
        }
        else if(num == 2)
        {
            piano2.Play();
        }
        else if(num == 3)
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
        
    }
    

}
