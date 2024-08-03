using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Training : MonoBehaviour
{
    [SerializeField] private Image _arrow;
    [SerializeField] private Image _text;
    [SerializeField] private GameOverScreen _gameOver;
    [SerializeField] private Image _text1;
    [SerializeField] private Image _arrow1;
    [SerializeField] private Image _text2;
    [SerializeField] private Image _arrow2;
    [SerializeField] private Image _text3;
    [SerializeField] private Image _text4;
    [SerializeField] private List<Image> _gameObjects;
    [SerializeField] private GameObject _training;
    [SerializeField] private GameObject _trainingButton;


    private bool _isDone = false;
    private bool _isDone1 = false;
    private int _isPlay = 0;

    private void Start()
    {
        _isPlay = PlayerPrefs.GetInt("_isPlay");

        if (_isPlay == 1)
        {
            _training.SetActive(false);
            _trainingButton.SetActive(false);
        }

        if (_isPlay == 0)
        {
            _arrow.gameObject.SetActive(true);
            _text.gameObject.SetActive(true);
            _isPlay = 1;
        }    
    }

    private void Update()
    {
        if (_gameOver.GetCountFoods() == 12)
        {
            _text1.gameObject.SetActive(false);

            if (_isDone == false)
            {
                OpenGameObject(_arrow1);
                OpenGameObject(_text2);
                _isDone = true;
            }

            for (int i = 0; i < _gameOver.ReturnFoods().Count; i++)
            {
                if (_gameOver.ReturnFoods()[i].ReturnIsClick())
                {
                    OffGameObject(_arrow1);
                    OffGameObject(_text2);
                    
                    if (_isDone1 == false)
                    {
                        OpenGameObject(_arrow2);
                        OpenGameObject(_text3);
                        _isDone1 = true;
                    }
                }
            }
        }
    }

    public void SaveTraining()
    {
        PlayerPrefs.SetInt("_isPlay", _isPlay);
    }

    public void OffGameObject(Image image)
    {
        image.gameObject.SetActive(false);
    }

    public void OffObject()
    {
        _arrow2.gameObject.SetActive(false);
        _text3.gameObject.SetActive(false);
    }

    public void OffText()
    {
        _text4.gameObject.SetActive(false);
    }

    public void OpenObject()
    {
        _text4.gameObject.SetActive(true);
    }

    public void OpenArrow(Image image)
    {
        if(_gameObjects.Count != 5)
        {
            image.gameObject.SetActive(true);
            _gameObjects.Add(image);
        }
    }

    public void OpenGameObject(Image image)
    {
        image.gameObject.SetActive(true);
    }
}
