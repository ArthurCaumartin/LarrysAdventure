using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] public string sceneToLoad;

    public void LoadScene()
    {
        Time.timeScale = 0;
        Transitioner.instance.SceneTransition(() =>
        {
            SceneManager.LoadScene(sceneToLoad);
        }, () => Time.timeScale = 1);
    }
}
