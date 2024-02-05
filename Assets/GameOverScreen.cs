using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private List<Food> _foods;
    [SerializeField] private List<int> _foodsCount;
    [SerializeField] private List<string> _titleFoods;
    [SerializeField] private ShowReward _reward;  
    
    private bool GameOver = true;  
    
    private int _watermelon = 0;
    private int _cherry = 0;
    private int _cheese = 0;
    private int _hotDog = 0;
    private int _olive = 0;
    private int _hamburger = 0;
    private int _banana = 0;

    private void Start()
    {
        _foodsCount.Add(_watermelon);
        _foodsCount.Add(_banana);
        _foodsCount.Add(_cherry);
        _foodsCount.Add(_olive);
        _foodsCount.Add(_hamburger);
        _foodsCount.Add(_cheese);
        _foodsCount.Add(_hotDog);

        _titleFoods.Add("Арбуз");
        _titleFoods.Add("Банан");
        _titleFoods.Add("Черри");
        _titleFoods.Add("Оливка");
        _titleFoods.Add("Гамбургер");
        _titleFoods.Add("Сыр");
        _titleFoods.Add("ХотДог");
    }

    private void Update()
    {
        CheckNull();
        CheckFood();

        if (_foods.Count == 12)
        {
            CheckCountFood();
        }
    }

    public void AddFood(Food food)
    {
        _foods.Add(food);
    }

    public void OpenPanel()
    {
        _reward.PlayRewardAfterDie();
        _gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(0);
    }

    public int GetCountFoods()
    {
        return _foods.Count;
    }

    public List<Food> ReturnFoods()
    {
        return _foods;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void ClearFoodCount(string title)
    {
        for (int x = 0; x < _titleFoods.Count; x++)
        {
            if (title == _titleFoods[x])
            {
                if (_foodsCount[x] >= 3)
                {
                    _foodsCount[x] -= 3;
                    break;
                }
            }
        }
    }

    private void CheckCountFood()
    {
        for (int i = 0; i < _foodsCount.Count; i++)
        {
            if (_foodsCount[i] >= 3)
            {
                GameOver = false;
                break;
            }
        }

        if (GameOver == true)
        {
            OpenPanel();
        }

        GameOver = true;
    }

    private void CheckFood()
    {
        for (int i = 0; i < _foods.Count; i++)
        {
            if (_foods[i].CheckIsCreate() == false)
            {
                for (int x = 0; x < _titleFoods.Count; x++)
                {
                    if (_foods[i].Title == _titleFoods[x])
                    {
                        _foodsCount[x] += 1;
                        _foods[i].ChangeIsCreate();
                    }
                }
            }
        }
    }

    private void CheckNull()
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
