using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Color _startColor;

    private void Start()
    {
        _startColor = GetComponent<Renderer>().material.color;
    }

    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = _startColor;
    }
}