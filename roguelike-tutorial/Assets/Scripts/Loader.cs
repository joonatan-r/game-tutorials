using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public GameObject gameManager;

    // Fix bug in the tutorial (at least in current Unity version):
    // replace the "Awake" function with a scene load listener

    /*void Awake()
    {
        if (GameManager.instance == null)
            Instantiate(gameManager);
    }*/

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (GameManager.instance == null)
            Instantiate(gameManager);
    }
}
