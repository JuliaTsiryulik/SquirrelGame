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

    static public bool isObstacle = false;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        charModel.GetComponent<Animator>().Play("Hit");

        levelConrol.GetComponent<LevelDistance>().enabled = false;
        thePlayer.GetComponent<PlayerMove>().enabled = false;

        crashThud.Play();

        isObstacle = true;

        mainCam.GetComponent<Animator>().enabled = true;        

        var searchHeartsContainer = GameObject.Find("Hearts");

        searchHeartsContainer.GetComponent<HeartsCounter>().LosingLife();

        this.gameObject.SetActive(false);
    }
}
