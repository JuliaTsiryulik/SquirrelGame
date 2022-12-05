using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;
    public GameObject mainCam;
    public GameObject levelConrol;

    public AudioSource crashThud;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMove>().enabled = false;

        //charModel.GetComponent<Character>().enabled = false;

        charModel.GetComponent<Animator>().Play("Hit");


        levelConrol.GetComponent<LevelDistance>().enabled = false;

        
        crashThud.Play();

        Character.isDead = true;

        mainCam.GetComponent<Animator>().enabled = true;

        levelConrol.GetComponent<EndRunSequence>().enabled = true;
    }
}
