using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveFood : MonoBehaviour
{
    [SerializeField] private List<Lane> _lanes;
    [SerializeField] private Training _training;

    private Food _firstClickFood;
    private Food _secondClickFood;
    private Lane _firstLane;
    private Lane _secondLane;  
    private bool _isDone = false;
    
    private void Update()
    {
        for (int i = 0; i < _lanes.Count; i++)
        {
            if(_firstClickFood == null)
            {
                _firstClickFood = _lanes[i].GetFood();
                _firstLane = _lanes[i];
                _lanes[i].DeleteCurrentFood();
            }

            if (_secondClickFood == null)
            {
                _secondClickFood = _lanes[i].GetFood();
                _secondLane = _lanes[i];
                _lanes[i].DeleteCurrentFood();  
            }
        }

        if(_firstClickFood != null && _secondClickFood != null)
        {
            Vector3 position = _firstClickFood.transform.position;
            _firstClickFood.transform.position = _secondClickFood.transform.position;
            _secondClickFood.transform.position = position;
            _firstLane.SetFood(_secondClickFood);
            _secondLane.SetFood(_firstClickFood);
            _firstClickFood = null;
            _secondClickFood = null;
            _training.OffObject();
            _training.OffObject();
            
            if(_isDone == false)
            {
                _training.OpenObject();
                _isDone = true;
            }
        }
    }
}
