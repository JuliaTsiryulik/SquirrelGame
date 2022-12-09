using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsCounter : MonoBehaviour
{
    public GameObject[] lifeHearts;
    //public GameObject heart1, heart2, heart3;
    public GameObject levelControl;
    public int health = 3;
    public int heart = 0;

    GameObject currentHeart;

    void LosingLife()
    {
        if (ObstacleCollision.isObstacle == true)
        {
            currentHeart = lifeHearts[heart];
            //heart1.GetComponent<Animator>().Play("Heart");
            currentHeart.GetComponent<Animator>().Play("Heart");
            heart += 1;
            health -= 1;

            ObstacleCollision.isObstacle = false;
        }

        if (health == 0)
        {
            Character.isDead = true;
            levelControl.GetComponent<EndRunSequence>().enabled = true;
        }

    }
}
