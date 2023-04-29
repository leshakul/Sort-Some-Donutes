using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Food> _prefabs;
    [SerializeField] private Vector3 _startPosition;

    private bool _isClick = false;

    private Food _currentFood;

    public void CreateFood()
    {
        if(_isClick == false)
        {
            Food food = _prefabs[GetRandomIndex()];
            _currentFood = Instantiate(food, _startPosition, food.transform.rotation);
            _isClick = true;
        }      
    }

    private int GetRandomIndex()
    {
        int randomIndex = Random.Range(0, _prefabs.Count);

        return randomIndex;
    }   

    public Food InstantiateFood(Vector3 position)
    {
        Food food = _currentFood;
        _currentFood.DestroyMe();
        _isClick = false;
        return Instantiate(food, position, food.transform.rotation);
    }
}
