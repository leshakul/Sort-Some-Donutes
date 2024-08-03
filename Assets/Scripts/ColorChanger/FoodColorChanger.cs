using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodColorChanger : MonoBehaviour
{
    [SerializeField] private List<Material> _materials;
    private MoveFood _moveFood;

    private Color _startColor;
    private Color _inputColor = Color.green;

    private void OnEnable()
    {
       
    }

    private void OnDisable()
    {
        
    }

    private void OnMouseDown()
    {
        for (int i = 0; i < _materials.Count; i++)
        {
            _materials[i].color = _inputColor;
        }       
    }

    public void BackChangeColor()
    {
        for (int i = 0; i < _materials.Count; i++)
        {
            _materials[i].color = _startColor;
        }
    }
}
