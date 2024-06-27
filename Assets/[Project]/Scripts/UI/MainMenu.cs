using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;
    [SerializeField] private float _transitionAnimationTime;
    [SerializeField] AnimationCurve _animationCurve;
    [Space]
    [SerializeField] private MainMenuElement _titleElement;
    [SerializeField] private MainMenuElement _levelElement;
    [SerializeField] private MainMenuElement _optionElement;
    [Space]
    [SerializeField] private GameObject _menuButtonPrefab;
    [SerializeField] private RectTransform _levelButtonParent;

    private MainMenuElement _currentElement;
    private List<Level> _levelList;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _titleElement.Show(_transitionAnimationTime, _animationCurve);
        _currentElement = _titleElement;
    }

    public void ShowElement(MainMenuElement elementToShow)
    {
        _currentElement.Hide(_transitionAnimationTime, _animationCurve
                             , () => elementToShow.Show(_transitionAnimationTime, _animationCurve));
        _currentElement = elementToShow;
    }

    public void BakeLevelButton(List<Level> levelList)
    {
        _levelList = levelList;

        for (int i = 0; i < _levelList.Count; i++)
        {
            GameObject newButton = Instantiate(_menuButtonPrefab, _levelButtonParent);
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = _levelList[i].levelName;
            newButton.GetComponent<Image>().sprite = levelList[i].buttonSprite;

            if (levelList[i].sceneName == "")
            {
                newButton.GetComponent<Button>().enabled = false;
            }
            else
                newButton.GetComponent<ButtonLevel>().Initialise(levelList[i].sceneName, levelList[i].fruitTaken);
        }
    }
}
