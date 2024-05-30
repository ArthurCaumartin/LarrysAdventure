using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public UnityEvent OnPlayerPrefReset;
    
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
        //TODO extract to SceneLoader class
        Time.timeScale = 0;
        Transitioner.instance.LarryTransition(() =>
        {
            SceneManager.LoadScene(sceneName);
        }, () => Time.timeScale = 1);
    }

    public void ResetCurrentLevel()
    {
        //TODO extract to SceneLoader class
        Time.timeScale = 0;
        Transitioner.instance.ResetLevelTransition(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }, () => Time.timeScale = 1);
    }
}
