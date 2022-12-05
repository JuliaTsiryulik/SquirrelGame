using UnityEngine;
using System;

/// <summary>
/// Mainly used as a data container to define a character. This script is attached to the prefab
/// (found in the Bundles/Characters folder) and is to define all data related to the character.
/// </summary>
public class Character : MonoBehaviour
{
    public string characterName;
    public int cost;
    public int premiumCost;

    public CharacterAccessories[] accessories;

    public Animator animator;
    public Sprite icon;

    [Header("Sound")]
    public AudioClip jumpSound;
    public AudioClip hitSound;
    public AudioClip deathSound;

    public AudioSource cat;

    static public bool isDead = false;
    static public bool isJumped = false;
    static public bool isFell = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        cat = GetComponent<AudioSource>();
       // gameObject.tag = "Player";
    }

    // Called by the game when an accessory changes, enable/disable the accessories children objects accordingly
    // a value of -1 as parameter disables all accessory.
    public void SetupAccesory(int accessory)
    {
        for (int i = 0; i < accessories.Length; ++i)
        {
            accessories[i].gameObject.SetActive(i == PlayerData.instance.usedAccessory);
        }
    }

    /*public void Dead()
    {
        if (isDead == true)
        {
            cat.PlayOneShot(deathSound);
        }
        
    }*/

    void Update()
    {
        if (isDead == true)
        {
            cat.PlayOneShot(deathSound);
            isDead = false;
        }

        if (isJumped == true)
        {
            cat.PlayOneShot(jumpSound);
            isJumped = false;
        }

        if (isFell == true)
        {
            cat.PlayOneShot(deathSound);
            isFell = false;
        }
    }
}
