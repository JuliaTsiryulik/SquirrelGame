using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStar : MonoBehaviour
{
    public AudioSource starFX;

    void OnTriggerEnter(Collider other)
    {
        starFX.Play();

        CollectableControll.starCount += 1;

        this.gameObject.SetActive(false);
    }
}
