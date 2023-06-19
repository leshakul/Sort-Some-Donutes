using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MoveFood : MonoBehaviour
{
    [SerializeField] private List<Lane> _lanes;
    [SerializeField] private Training _training;
    [SerializeField] private MouseInput _mouseInput;

    private Food _firstClickFood;
    private Food _secondClickFood; 
    private bool _isDone = false;
    private bool asd = false;

    private void OnEnable()
    {
        _mouseInput.FoodIsClick += GetFood;
    }

    private void OnDisable()
    {
        _mouseInput.FoodIsClick -= GetFood;
    }

    private void GetFood(Food food)
    {
        if(_firstClickFood == null)
        {
            _firstClickFood = food;
        }
        
        if(_secondClickFood == null && food != _firstClickFood)
        {
            _secondClickFood = food;
        }

        if (_firstClickFood != null && _secondClickFood != null && asd == false)
        {
            MoveFoods();
                      
            asd = true;
        }
    } 

    private void ResetFood()
    {
        _firstClickFood = null;
        _secondClickFood = null;
        Debug.Log("asd");
    }
    
    private void MoveFoods()
    {       
        Vector3 position = _firstClickFood.transform.position;
        _firstClickFood.transform.position = _secondClickFood.transform.position;
        _secondClickFood.transform.position = position;       
        //_firstLane.SetFood(_secondClickFood, _firstClickFoodId);
        //_secondLane.SetFood(_firstClickFood, _secondClickFoodId);          
        _training.OffObject();
        _training.OffObject();
            
        if (_isDone == false)
        {
            _training.OpenObject();
            _isDone = true;
         }

        ResetFood();
    }
}
