using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private bool _takeSaveData = false;
    [SerializeField] public GameData _gameData;
    [Space]
    [SerializeField] private SkinManager _skinManager;
    private PlayerPrefRecorder _playerRecorder;
    private SoundManager _soundManager;

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
        _soundManager = GetComponentInChildren<SoundManager>();
        _playerRecorder = GetComponent<PlayerPrefRecorder>();


        if (_takeSaveData)
        {
            _gameData.coinQuantity = _playerRecorder.GetData("coin");
            for (int i = 0; i < _gameData.levelList.Count; i++)
            {
                for (int y = 0; y < _gameData.levelList[i].fruitTaken.Length; y++)
                {
                    print("Data to Get : " + _gameData.levelList[i].sceneName + y);
                    _gameData.levelList[i].fruitTaken[y] = _playerRecorder.GetDataBool(_gameData.levelList[i].sceneName + y);
                }
            }
        }

        MainMenu.instance?.BakeLevelButton(_gameData.levelList);
        CanvasManager.instance?.SetCoinText(_gameData.coinQuantity);
        _skinManager?.SetSkinFromData(_gameData.baseSkin, _gameData.skinList);
    }

    public void OnEndLevel()
    {
        print("");
        CanvasManager.instance.SetEndLevelUI();
    }

    public void FruitTaken(string sceneName, int index)
    {
        print("Record : " + sceneName + index);
        _playerRecorder.SaveData(sceneName + index, 1);
        CanvasManager.instance.SetFruitImage(index);
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
        _soundManager.PlayCoinSfx();
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
