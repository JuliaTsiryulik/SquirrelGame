using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitScene : MonoBehaviour
{
    public GameObject leaveScreen;
    public GameObject pauseScreen;

    //public string _mainMenu;

    public void QuitInvoke()
    {
        pauseScreen.SetActive(false);
        leaveScreen.SetActive(true);
    }

    public void Stay()
    {
        pauseScreen.SetActive(true);
        leaveScreen.SetActive(false);
    }

    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
