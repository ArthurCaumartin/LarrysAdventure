using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonLevel : MonoBehaviour
{
    [SerializeField] public string _sceneToLoad;
    [SerializeField] private GameObject _fruitImagePrefab;
    [SerializeField] private List<Image> _fruitImageList;

    private RectTransform _rectTransform;

    public void Initialise(string sceneToLoad, bool[] fruitStateList)
    {
        _rectTransform = (RectTransform)transform;

        // print("Button Initialize : " + fruitStateList.Length);
        // print("Button Width : " + _rectTransform.rect.width);


        _sceneToLoad = sceneToLoad;

        for (int i = 0; i < fruitStateList.Length; i++)
        {
            GameObject newFruit = Instantiate(_fruitImagePrefab, transform);
            ((RectTransform)newFruit.transform).anchoredPosition =
            new Vector3(Mathf.Lerp(-_rectTransform.rect.width / 2, _rectTransform.rect.width / 2, Mathf.InverseLerp(0, fruitStateList.Length, i)), _rectTransform.rect.height, 0);
            newFruit.GetComponent<Image>().color = fruitStateList[i] ? Color.white : Color.grey;
        }
    }

    public void LoadScene()
    {
        Time.timeScale = 0;
        Transitioner.instance.SceneTransition(() =>
        {
            SceneManager.LoadScene(_sceneToLoad);
        }, () => Time.timeScale = 1);
    }
}
