using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public AudioSource lostSound;

    public AudioSource winSound;
    void Start()
    {
    }

    
    void Update()
    {
    }


    void OnCollisionEnter(Collision other)
    {
        //Puanlamayı collide ettiği finish levele göre yapılabilir
        if(other.gameObject.tag == "Obstacle"){
            lostSound.Play();
            GameManager.Instance.UpdateGameState(GameState.PlayerDead);
        }
        else if(other.gameObject.tag == "Finish"){
            winSound.Play();
            GameManager.Instance.UpdateGameState(GameState.LevelFinished);
        }
    }
}
