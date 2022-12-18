using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public static float currentSpeed;
    public float maxSpeed = 20f;
    public float minSpeed = 5f;
    public float leftRightSpeed = 5f;
    public GameObject charModel;

    private float power;

    static public bool canMove = false;
    static public bool isSpaced = false;


    void Start()
    {
        currentSpeed = minSpeed;
    }


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
            transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed, Space.World);

            if (currentSpeed < maxSpeed)
            {
                currentSpeed += 0.1f * Time.deltaTime;
            }

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
