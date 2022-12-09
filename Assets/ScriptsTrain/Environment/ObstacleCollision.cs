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

    public HeartsCounter loseLife;
    static public bool isObstacle = false;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMove>().enabled = false;

        //charModel.GetComponent<Character>().enabled = false;

        charModel.GetComponent<Animator>().Play("Hit");

        levelConrol.GetComponent<LevelDistance>().enabled = false;

        crashThud.Play();

        //Character.isDead = true;
        isObstacle = true;

        mainCam.GetComponent<Animator>().enabled = true;

        //loseLife.LosingLife();
        //???????????levelConrol.GetComponent<HeartsCounter>().enabled = true;

        //levelConrol.GetComponent<EndRunSequence>().enabled = true;
    }
}
