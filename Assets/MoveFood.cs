using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class MoveFood : MonoBehaviour
{
    [SerializeField] private List<Lane> _lanes;
    [SerializeField] private Training _training;
    [SerializeField] private MouseInput _mouseInput;

    private Food _firstClickFood;
    private Food _secondClickFood;
    public Lane _firstLane;
    public Lane _secondLane;
    private bool _isDone = false;
    private bool asd = false;
    private bool _isMoving;

    private void OnEnable()
    {
        _mouseInput.FoodIsClick += GetFood;
        _mouseInput.LaneIsClick += GetLane;
    }


    private void OnDisable()
    {
        _mouseInput.FoodIsClick -= GetFood;
        _mouseInput.LaneIsClick -= GetLane;
    }

    private void GetLane(Lane lane)
    {
        if (_secondLane == null && _firstLane != null && !_isMoving)
        {
            _secondLane = lane;                     
        }

        if (_firstLane == null && !_isMoving)
        {
            _firstLane = lane;
        }

        if (_firstClickFood != null && _secondClickFood != null && asd == false)
        {
            MoveFoods();
        }
    }

    private void GetFood(Food food)
    {
        if (_firstClickFood == null)
        {
            _firstClickFood = food;
        }

        if (_secondClickFood == null && food != _firstClickFood)
        {
            _secondClickFood = food;
        }
    }

    private void ResetLane()
    {
        _firstLane = null;
        _secondLane = null;
    }

    private void ResetFood()
    {
        _firstClickFood = null;
        _secondClickFood = null;
    }

    private void MoveFoods()
    {        
        Vector3 position = _firstClickFood.transform.position;        
        _firstClickFood.transform.DOMove(new Vector3(_secondClickFood.transform.position.x, _secondClickFood.transform.position.y, _secondClickFood.transform.position.z), 0.3f);
        _secondClickFood.transform.DOMove(new Vector3(position.x, position.y, position.z), 0.3f);

        if(_firstLane == _secondLane)
        {
            _firstLane.SetFoodSameLane(_firstClickFood, _secondClickFood);
        }
        else
        {
            _firstLane.SetFoodDifferentLane(_secondClickFood, _firstLane.ReturnFoodId());
            _secondLane.SetFoodDifferentLane(_firstClickFood, _secondLane.ReturnFoodId());
        }
        
        _firstClickFood.OffClick();
        _secondClickFood.OffClick();
        _training.OffObject();
        StartCoroutine(DelayMove());
        ResetFood();
        ResetLane();

        if (_isDone == true)
        {
            _training.OffText();
            
        }

        if(_isDone == false)
        {
            _training.OpenObject();
            _isDone = true;
        }          
    }

    private IEnumerator DelayMove()
    {
        asd = true;
        _isMoving = true;
        yield return new WaitForSeconds(0.4f);
        asd = false;
        _isMoving = false;
    }
}
