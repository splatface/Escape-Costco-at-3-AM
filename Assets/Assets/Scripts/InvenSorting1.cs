using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InvenSorting1 : MonoBehaviour
{
    public TMP_Dropdown Sorting1;
    private int _index = 0;
    public FullInventory Inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ChangeSort(TMP_Dropdown newSort)
    {
        _index = newSort.value;
    }

    void Start()
    {
        Sorting1.onValueChanged.AddListener(delegate{ChangeSort(Sorting1);}); // calls this function; not mine :(
    }


    void Update()
    {
        if (_index == 0)
        {
            Inventory.ShowInvenItems();
        }
        else if (_index == 1)
        {
            
        }
    }
}
