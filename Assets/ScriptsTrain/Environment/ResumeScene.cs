using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class ResumeScene : MonoBehaviour
{
    public GameObject countDownStart;
    public GameObject pauseScreen;
    public void ResumeTheGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        countDownStart.SetActive(true);
    }
}
