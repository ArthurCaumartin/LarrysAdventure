using UnityEngine;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private float _transitionAnimationTime;
    [SerializeField] AnimationCurve _animationCurve;

    [SerializeField] private MainMenuElement _titleElement;
    [SerializeField] private MainMenuElement _levelElement;
    [SerializeField] private MainMenuElement _optionElement;

    private MainMenuElement _currentElement;

    void Start()
    {
        _titleElement.Show(_transitionAnimationTime, _animationCurve);
        _currentElement = _titleElement;
    }

    public void ShowElement(MainMenuElement elementToShow)
    {
        _currentElement.Hide(_transitionAnimationTime, _animationCurve
                             , () =>  elementToShow.Show(_transitionAnimationTime, _animationCurve));
        _currentElement = elementToShow;
    }
}
