using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lane : MonoBehaviour
{
    [SerializeField] private List<Food> _foods;
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private Player _player;
    [SerializeField] private GameOverScreen _gameOverScreen;

    public List<SpawnPoint> SpawnPoints => _spawnPoints;

    private void Update()
    {
        CheckForMatch();  
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

    public void SetFood(Food food, int id)
    {
        _foods[id] = food;
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
