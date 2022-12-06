using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    public GameObject countDownStart;
    public GameObject fadeIn;

    public AudioSource startFX;

    void Start()
    {
        //Time.timeScale = 0f;
        StartCoroutine(CountSequence());
        //Time.timeScale = 1;
    }

    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(0.4f);
        countDownStart.SetActive(true);

        startFX.Play();

        PlayerMove.canMove = true;
        //Character.isDead = true;
    }
}
