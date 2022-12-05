using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5;
    public float leftRightSpeed = 5;

    public GameObject charModel;

    //private float jumpAmount = 4f;
    private float power;

    static public bool canMove = false;
    static public bool isSpaced = false;

    //public AudioSource catDeath;


    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "MainMenu")
        {
            charModel.GetComponent<Animator>().Play("Happy");
        }
        else if (sceneName == "SampleScene")
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

            if (canMove == true)
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                    {
                        transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                    }
                }

                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                    {
                        transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
                    }
                }

                if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
                {
                    isSpaced = true;

                    if (Mathf.Abs(power) < 0.01f && this.gameObject.transform.position.y <= 0)
                    {
                        power = 5;

                        Character.isJumped = true;

                    }

                    /*if (this.gameObject.transform.position.y <= 0)
                    {
                       // transform.Translate(Vector3.up * Time.deltaTime * jumpAmount);
                    }*/
                }

                if (this.gameObject.transform.position.y > 0)
                {

                    power -= 15f * Time.deltaTime;
                }

                if (this.gameObject.transform.position.y < 0)
                {
                    var pos = this.gameObject.transform.position;
                    pos.y = 0;
                    this.gameObject.transform.position = pos;
                    power = 0;

                    isSpaced = false;
                }

                if (Mathf.Abs(power) > 0.01f)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * power);
                }

            }
            /*else
            {
                catDeath.Play();
            }*/
            if (isSpaced == true)
            {
                charModel.GetComponent<Animator>().Play("Jump");
            }
            else
            {
                charModel.GetComponent<Animator>().Play("runLoop");
            }
        }
        
    }
}
