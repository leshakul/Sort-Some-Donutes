using System.Collections.Generic;
using UnityEngine;


public class Lane : MonoBehaviour
{
    [SerializeField] private List<Food> _foods;
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private Player _player;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private int _laneId;
    
    private int _foodId;
    
    public List<SpawnPoint> SpawnPoints => _spawnPoints;
    

    private void Update()
    {
        CheckForMatch();
        SetIdOnFood();

        for (int i = 0; i < _foods.Count; i++)
        {
            if (_foods[i].IsClick == true)
            {
                _foodId = i;

                break;
            }
        }
    }

    public int ReturnFoodId()
    {       
        return _foodId;
    }

    public void SetIdOnFood()
    {
        foreach(Food food in _foods)
        {
            food.ChangeFoodId(_laneId);
        }
    }

    public void SetFoodSameLane(Food firstfood, Food secondfood)
    {
        int firstId = 0;
        int secondId = 0;

        for (int i = 0; i < _foods.Count; i++)
        {
            if (_foods[i] == firstfood)
            {
                firstId = i;
            }

            if (_foods[i] == secondfood)
            {
                secondId = i;
            }
        }

        _foods[firstId] = secondfood;
        _foods[secondId] = firstfood;

    }

    public void SetFoodDifferentLane(Food food, int id)
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

    private void CheckForMatch()
    {     
        try
        {
            if (_foods[0].Title == _foods[1].Title && _foods[0].Title == _foods[2].Title)
            {
                _gameOverScreen.ClearFoodCount(_foods[0].Title);

                for (int i = 0; i < _foods.Count; i++)
                {                   
                    _foods[i].DestroyFood();
                    _spawnPoints[i].IsEmpty = true;
                }

                _player.ScoreChange();
            }
        }
        catch
        {
        }
    }
}
