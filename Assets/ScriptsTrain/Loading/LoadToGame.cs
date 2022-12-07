using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadToGame : MonoBehaviour
{
    
    public void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        //string sceneName = currentScene.name;
        int sceneIndex = currentScene.buildIndex;

        if (sceneIndex == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (sceneIndex == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        
    }
}
