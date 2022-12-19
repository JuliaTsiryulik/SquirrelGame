using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsCounter : MonoBehaviour
{
    public GameObject[] lifeHearts;
    public GameObject levelControl;
    public int health = 3;
    public int heart = 0;

    public GameObject thePlayer;
    public GameObject charModel;
    public GameObject levelConrol;

    GameObject currentHeart;

    public void LosingLife()
    {
        if (heart < 0)
        {
            return;
        }

        currentHeart = lifeHearts[heart];
        currentHeart.GetComponent<Animator>().Play("Hearts");
        heart += 1;
        health -= 1;

        if (health == 0)
        {
            charModel.GetComponent<Animator>().Play("Death");
            Character.isDead = true;
            levelControl.GetComponent<EndRunSequence>().enabled = true;
        }
        else
        {
            StartCoroutine(ContinueRun());
        }

    }

    IEnumerator ContinueRun()
    {
        yield return new WaitForSeconds(1.4f);

        charModel.GetComponent<Animator>().Play("runStart");

        levelConrol.GetComponent<LevelDistance>().enabled = true;
        thePlayer.GetComponent<PlayerMove>().enabled = true;

    }
}
