using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private GameObject _endLevelPanel;
    [Space]
    [SerializeField] private TextMeshProUGUI coinUI;
    [SerializeField] private float _colorOffset;
    [SerializeField] private float _colorSpeed;
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private List<Image> _fruitImageList;
    private bool _isAllFruitTaken = false;

    void Start()
    {
        CanvasManager.instance.SetInGameUi(this);
        for (int i = 0; i < _fruitImageList.Count; i++)
            _fruitImageList[i].color = Color.gray;
    }

    public void SetEndLevelPanel(bool value)
    {
        Time.timeScale = value ? 0 : 1;
        _endLevelPanel.SetActive(value);
    }

    public void SetCoinText(int value)
    {
        _coinText.text = " : " + value;
    }

    public void GrabFruit(int index)
    {
        _fruitImageList[index].color = Color.white;

        _isAllFruitTaken = true;
        foreach (var item in _fruitImageList)
        {
            if (item.color != Color.white)
                _isAllFruitTaken = false;
        }
    }

    void Update()
    {
        if (!_isAllFruitTaken)
            return;

        for (int i = 0; i < _fruitImageList.Count; i++)
        {
            Color newColor = Color.HSVToRGB(Mathf.InverseLerp(1, -1, Mathf.Sin(Time.time * _colorSpeed + (i * _colorOffset))), 1, 1);
            _fruitImageList[i].color = newColor;
        }
    }

    //! For Button Event 

    public void LoadMenu()
    {
        Time.timeScale = 0;
        Transitioner.instance.SceneTransition(() =>
        {
            SceneManager.LoadScene("Menu");
        }, () => Time.timeScale = 1, true);
    }

    public void ResetScene()
    {
        Time.timeScale = 0;
        Transitioner.instance.SceneTransition(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }, () => Time.timeScale = 1);
    }
}
