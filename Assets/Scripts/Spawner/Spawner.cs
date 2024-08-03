using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Food> _prefabs;
    [SerializeField] private Vector3 _startPosition;

    private bool _isClick = false;

    private Food _currentFood;
    private Food _instatiatedFood;

    public void CreateFood()
    {
        if(_isClick == false)
        {
            Food food = _prefabs[GetRandomIndex()];
            _currentFood = Instantiate(food, _startPosition, food.transform.rotation);
            _isClick = true;
        }      
    }

    public Food ReturnInstantiateFood(Vector3 position)
    {
        _instatiatedFood = _currentFood;
        _currentFood.DestroyFood();
        _currentFood = null;
        _isClick = false;
        
        return Instantiate(_instatiatedFood, position, _instatiatedFood.transform.rotation);
    }

    private int GetRandomIndex()
    {
        int randomIndex = Random.Range(0, _prefabs.Count);

        return randomIndex;
    }
}
