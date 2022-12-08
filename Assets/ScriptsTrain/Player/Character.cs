using UnityEngine;
using System;

public class Character : MonoBehaviour
{
    public string characterName;

    public Animator animator;

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
    }

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
