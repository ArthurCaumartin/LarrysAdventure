using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] public GameData gameData;
    [Space]
    [SerializeField] private SkinManager _skinManager;
    private CanvasManager _canvasManager;
    
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

    void Start()
    {
        _canvasManager = GetComponent<CanvasManager>();

        // _canvasManager.SetCoinText(gameData.coinQuantity);
        // _canvasManager.SetLevelButtonInMenu(gameData.levelList);

        _skinManager?.SetSkinFromData(gameData.baseSkin, gameData.skinList);
    }

    public int GetCoinQuantity()
    {
        return gameData.coinQuantity;
    }

    public void BuyStuff(int price)
    {
        gameData.coinQuantity -= price;
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
