using UnityEngine;
using UnityEngine.Events;

public class Food : MonoBehaviour
{
    [SerializeField] private string _title;

    public bool IsClick { get; private set; }
    public int FoodId => _foodId;
    private int _foodId;

    private bool _isCreate = false;

    public string Title => _title;

    private void OnMouseDown()
    {
        IsClick = true;      
    }

    public void ChangeFoodId(int id)
    {
        _foodId = id;
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
        return IsClick;
    }

    public void OffClick()
    {
        IsClick = false;
    }

    public void DestroyFood()
    {
        Destroy(gameObject);
    }
}
