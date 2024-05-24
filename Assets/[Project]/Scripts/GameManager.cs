using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if(instance)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 0;
        Transitioner.instance.LarryTransition(() =>
        {
            SceneManager.LoadScene(sceneName);
        }, () => Time.timeScale = 1);
    }

    public void ResetCurrentLevel()
    {
        Time.timeScale = 0;
        Transitioner.instance.ResetLevelTransition(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }, () => Time.timeScale = 1);
    }
}
