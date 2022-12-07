using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitScene : MonoBehaviour
{
    public GameObject leaveScreen;
    public GameObject pauseScreen;


    public GameObject loadingScreen;
    public GameObject catModel;
    public GameObject decorations;
    public GameObject sky;
    public GameObject bgm;
    public GameObject canvas;
    public GameObject light;
    public GameObject footPath;

    public Slider slider;
    //public GameObject playerModel;

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
        StartCoroutine(LoadSceneAsync());

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1;
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);

        loadingScreen.SetActive(true);

        catModel.SetActive(false);
        decorations.SetActive(false);
        sky.SetActive(false);
        bgm.SetActive(false);
        canvas.SetActive(false);
        light.SetActive(false);
        footPath.SetActive(false);

        

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progressValue;

            yield return null;
        }
    }
}

