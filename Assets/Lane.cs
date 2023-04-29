using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Lane : MonoBehaviour
{
    [SerializeField] private List<Food> _foods;
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private Player _player;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private Food _currentFood;
    private int _currentId;

    public List<SpawnPoint> SpawnPoints => _spawnPoints;
    public List<Food> Foods => _foods;

    private void Update()
    {
        CheckForMatch();

        for (int i = 0; i < _foods.Count; i++)
        {
            if (_foods[i].ReturnIsClick() == true)
            {
                _currentFood = _foods[i];
                _currentId = i;
                _foods[i].OffClick();
            }
        }
    }

    private void CheckForMatch()
    {
        try
        {
            if (_foods[0].Title == _foods[1].Title && _foods[0].Title == _foods[2].Title)
            {
                _gameOverScreen.ClearFoodCount(_foods[0].Title);

                for (int i = 0; i < _foods.Count; i++)
                {
                    _foods[i].DestroyMe();
                    _spawnPoints[i].IsEmpty = true;
                }

                _player.ScoreChange();
            }
        }
        catch
        {
        }
    }

    public Food GetFood()
    {
        return _currentFood;
    }

    public void DeleteCurrentFood()
    {
        _currentFood = null;
    }

    public void SetFood(Food food)
    {
        _foods[_currentId] = food;
    }  

    public void AddFood(Food food)
    {
        _foods.Add(food);
    }

    public void CheckNull()
    {
        for (int i = 0; i < _foods.Count; i++)
        {
            if (_foods[i] == null)
            {
                _foods.Remove(_foods[i]);
            }
        }
    }
}
