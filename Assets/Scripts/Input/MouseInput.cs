using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MouseInput : MonoBehaviour
{
    public UnityAction<Lane> LaneIsClick;
    public UnityAction<Food> FoodIsClick;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit[] hitColliders = Physics.RaycastAll(ray);

            foreach(RaycastHit hit in hitColliders)
            {
                if (hit.collider.gameObject.TryGetComponent(out Food food))
                {
                    if (food.ReturnIsClick() == true)
                    {
                        FoodIsClick?.Invoke(food);

                        foreach (RaycastHit Hit in hitColliders)
                        {
                            if (Hit.collider.gameObject.TryGetComponent(out Lane lane))
                            {
                                LaneIsClick?.Invoke(lane);
                            }
                        }
                    }                   
                }                
            }           
        }
    }
}
