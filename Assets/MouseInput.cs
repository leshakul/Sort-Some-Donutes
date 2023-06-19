using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MouseInput : MonoBehaviour
{
    public Food _food;
    public UnityAction<Food> FoodIsClick;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.GetComponent<Food>())
                {
                    if(_food == null)
                    {
                        _food = hit.collider.gameObject.GetComponent<Food>();
                    }

                    FoodIsClick?.Invoke(_food);
                    _food = null;
                }
            }
        }      
    }
}
