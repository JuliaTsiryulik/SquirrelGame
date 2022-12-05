using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFalling : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;
    public GameObject mainCam;
    public GameObject levelConrol;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMove>().enabled = false;

        charModel.GetComponent<Animator>().Play("Falling");

        levelConrol.GetComponent<LevelDistance>().enabled = false;

        //crashThud.Play();

        Character.isFell = true;

        mainCam.GetComponent<Animator>().enabled = true;
        //mainCam.GetComponent<Animator>().Play("CamUpShake");

        levelConrol.GetComponent<EndRunSequence>().enabled = true;
    }
}
