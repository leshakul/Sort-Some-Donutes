using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class Training : MonoBehaviour
{
    [SerializeField] private GameObject _arrow;
    [SerializeField] private GameObject _text;
    [SerializeField] private GameOverScreen _gameOver;
    [SerializeField] private GameObject _text1;
    [SerializeField] private GameObject _arrow1;
    [SerializeField] private GameObject _text2;
    [SerializeField] private GameObject _arrow2;
    [SerializeField] private GameObject _text3;
    [SerializeField] private GameObject _text4;

    [SerializeField] private List<GameObject> _gameObjects;
    private bool _isDone = false;
    private bool _isDone1 = false;


    private void Start()
    {
        _arrow.SetActive(true);
        _text.SetActive(true);
    }

    public void OffGameObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public void OffObject()
    {
        _arrow2.SetActive(false);
        _text3.SetActive(false);
    }

    public void OpenObject()
    {
        _text4.SetActive(true);
    }

    public void OpenArrow(GameObject gameObject)
    {
        if(_gameObjects.Count != 5)
        {
            gameObject.SetActive(true);
            _gameObjects.Add(gameObject);
        }
    }

    public void OpenGameObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    private void Update()
    {
        if(_gameOver.GetCountFoods() == 12)
        {
            _text1.SetActive(false);
            if(_isDone == false)
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
                    if(_isDone1 == false)
                    {
                        OpenGameObject(_arrow2);
                        OpenGameObject(_text3);
                        _isDone1 = true;
                    }                   
                }   
            }
        }

        for (int i = 0; i < _gameOver.ReturnFoods().Count; i++)
        {
            if (_gameOver.ReturnFoods()[i].ReturnIsClick())
            {
                OffGameObject(_text4);
            }
        }
    }
}
