using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] public GameData _gameData;
    [Space]
    [SerializeField] private SkinManager _skinManager;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        CanvasManager.instance?.SetCoinText(_gameData.coinQuantity);
        _skinManager?.SetSkinFromData(_gameData.baseSkin, _gameData.skinList);
    }

    public int GetCoinQuantity()
    {
        return _gameData.coinQuantity;
    }

    public void BuyStuff(int price)
    {
        _gameData.coinQuantity -= price;
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
        Transitioner.instance.ResetLevelTransition(
            () =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            },
            () => Time.timeScale = 1
        );
    }
}
