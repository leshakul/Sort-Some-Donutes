using UnityEngine;
using UnityEngine.Events;

public class Food : MonoBehaviour
{
    [SerializeField] private string _title;

    public bool _isClick = false;
    private bool _isCreate = false;

    public string Title => _title;

    private void OnMouseDown()
    {
        _isClick = true;      
    }

    public bool CheckIsCreate()
    {
        return _isCreate;
    }

    public void ChangeIsCreate()
    {
        _isCreate = true;
    }

    public bool ReturnIsClick()
    {
        return _isClick;
    }

    public void OffClick()
    {
        _isClick = false;
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
