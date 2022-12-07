using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingNextScene : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject playerModel;
    public GameObject options;
    public GameObject playButton;
    public GameObject quitButton;

    public Image loadingBarFill;

    public void LoadScene()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        loadingScreen.SetActive(true);
        playerModel.SetActive(false);
        options.SetActive(false);
        playButton.SetActive(false);
        quitButton.SetActive(false);

        yield return new WaitForSeconds(2);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            loadingBarFill.fillAmount = progressValue;

            yield return null;
        }
    }
}
