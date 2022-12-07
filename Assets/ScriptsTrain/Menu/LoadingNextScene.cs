using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using System.Threading.Tasks;

public class LoadingNextScene : MonoBehaviour
{
    
    public GameObject loadingScreen;
    public GameObject playerModel;
    public GameObject options;
    public GameObject quitButton;
    public GameObject playButton;

    //public Image loadingBarFill;
    public Slider slider;


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
        quitButton.SetActive(false);
        playButton.SetActive(false);

        

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progressValue;

            yield return null;
        }
        //yield return new WaitForSeconds(3);
    }

}


/*public static LoadingNextScene Instance;

    [SerializeField] private GameObject _loaderCanvas;
    [SerializeField] private Image _progressBar;
    private float _target;

    public GameObject playerModel;
    public GameObject options;
    public GameObject quitButton;
    public GameObject playButton;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async void LoadScene(string sceneName)
    {
        _target = 0;
        _progressBar.fillAmount = 0;

        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        _loaderCanvas.SetActive(true);
        playerModel.SetActive(false);
        options.SetActive(false);
        quitButton.SetActive(false);
        playButton.SetActive(false);

        do
        {
            await Task.Delay(100);
            _target = scene.progress;
        }
        while (scene.progress < 0.9f);

        await Task.Delay(1000);

        scene.allowSceneActivation = true;

        _loaderCanvas.SetActive(false);
        playerModel.SetActive(true);
        options.SetActive(true);
        quitButton.SetActive(true);
        playButton.SetActive(true);
    }

    void Update()
    {
        _progressBar.fillAmount = Mathf.MoveTowards(_progressBar.fillAmount, _target, 3 * Time.deltaTime);
    }*/