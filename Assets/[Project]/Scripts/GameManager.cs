using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] public GameData _gameData;
    [Space]
    [SerializeField] private SkinManager _skinManager;
    private PlayerPrefRecorder _playerRecorder;

    private void Awake()
    {
        transform.parent = null;
        if (instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        _playerRecorder = GetComponent<PlayerPrefRecorder>();
        _gameData.coinQuantity = _playerRecorder.GetData("coin");

        CanvasManager.instance?.SetCoinText(_gameData.coinQuantity);
        _skinManager?.SetSkinFromData(_gameData.baseSkin, _gameData.skinList);
    }

    public int GetCoinQuantity()
    {
        return _gameData.coinQuantity;
    }

    public void AddCoin(int value)
    {
        _gameData.coinQuantity += value;
        CanvasManager.instance.SetCoinText(_gameData.coinQuantity);
        _playerRecorder.SaveData("coin", _gameData.coinQuantity);
    }

    public void BuyStuff(int price)
    {
        _gameData.coinQuantity -= price;
        CanvasManager.instance.SetCoinText(_gameData.coinQuantity);
        _playerRecorder.SaveData("coin", _gameData.coinQuantity);
    }

    public void LoadScene(string sceneName)
    {
        //TODO extract to SceneLoader class
        Time.timeScale = 0;
        Transitioner.instance.SceneTransition(() =>
        {
            SceneManager.LoadScene(sceneName);
        }, () => Time.timeScale = 1);
    }

    public void ResetCurrentLevel()
    {
        //TODO extract to SceneLoader class
        Time.timeScale = 0;
        Transitioner.instance.FastTransition(
            () =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            },
            () => Time.timeScale = 1
        );
    }
}
