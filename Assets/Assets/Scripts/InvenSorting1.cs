using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InvenSorting1 : MonoBehaviour
{
    public TMP_Dropdown Sorting1;
    private int _index = 0;

    private static char[] _alphaOrder = new char[26] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

    private bool _needChange = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ChangeSort(TMP_Dropdown newSort)
    {
        _index = newSort.value;
        _needChange = true;
    }

    public string[] AlphaSort(string[] sortArray)
    {
        for (int initialPosition=0; initialPosition<sortArray.Length; initialPosition += 1)
        {
            
        }

        return sortArray;
        
    }

    void Start()
    {
        Sorting1.onValueChanged.AddListener(delegate{ChangeSort(Sorting1);}); // calls this function; not mine :(
    }


    void Update()
    {
        if (_index == 0 && _needChange == true)
        {
            FullInventory.Instance.ShowInvenItems();
            _needChange = false;
        }
        else if (_index == 1) //alphabetical sorting
        {
            
        }
    }
}
