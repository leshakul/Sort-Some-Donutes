using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Lane _lane;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private Training _training;
    [SerializeField] private List<Image> _arrows;
    [SerializeField] private Image _text;
    [SerializeField] private Image _text1;

    private bool _isDone = false;
    private Food food;

    private void OnMouseDown()
    {
        for (int i = 0; i < _lane.SpawnPoints.Count; i++)
        {
            if (_lane.SpawnPoints[i].IsEmpty != false)
            {
                try
                {
                    food = _spawner.ReturnInstantiateFood(_lane.SpawnPoints[i].transform.position);
                    _lane.AddFood(food);
                    _training.OffGameObject(_arrows[0]);
                    _training.OffGameObject(_arrows[1]);
                    _training.OffGameObject(_arrows[2]);
                    _training.OffGameObject(_arrows[3]);
                    _training.OffGameObject(_text);
                }
                catch
                {
                    break;
                }
                               
                if(_isDone == false)
                {
                    _training.OpenGameObject(_text1);
                    _isDone = true;
                }

                _gameOverScreen.AddFood(food);
                _lane.SpawnPoints[i].IsEmpty = false;
                break;
            }
        }
    }

    private void Update()
    {
        _lane.CheckNull();
    }
}
