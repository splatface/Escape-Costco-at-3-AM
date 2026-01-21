using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InvenSorting2 : MonoBehaviour
{
    public TMP_Dropdown Sorting2;
    public InvenSorting1 Sorting1;
    private int _index = 0;

    private bool _needChange = false;
    public void ChangeSort(TMP_Dropdown newSort)
    {
        _index = newSort.value;
        _needChange = true;
    }

    public int GetIndex()
    {
        return _index;
    }

    public string[] SortItemType(string[] sortArray)
    {
        List<string> weaponTags = new List<string>();
        List<string> interactableItemTags = new List<string>();
        List<string> powerupTags = new List<string>();
        List<string> keycardTags = new List<string>();

        foreach (string tag in sortArray)
        {
            GameObject item = GameObject.FindWithTag(tag);
            ItemBase actualItem = item.GetComponent<ItemBase>();

            // logic to do initial sorting for items into the respective lists
            string itemType = actualItem.Type.ToLower();

            if (itemType == "weapon")
            {
                weaponTags.Add(tag);
            }
            else if (itemType == "interactable")
            {
                interactableItemTags.Add(tag);
            }
            else if (itemType == "powerup")
            {
                powerupTags.Add(tag);
            }
            else
            {
                keycardTags.Add(tag);
            }
        }

        // assembling all of the items into one final list
        List<string> finalList = new List<string>();

        foreach (string weapon in weaponTags)
        {
            finalList.Add(weapon);
        }
        foreach (string interactableItem in interactableItemTags)
        {
            finalList.Add(interactableItem);
        }
        foreach (string powerup in powerupTags)
        {
            finalList.Add(powerup);
        }
        foreach (string keycard in keycardTags)
        {
            finalList.Add(keycard);
        }

        return finalList.ToArray(); // return + change list to array
    }
    
    void Start()
    {
        Sorting2.onValueChanged.AddListener(delegate{ChangeSort(Sorting2);}); // calls this function; not my code
    }


    void Update()
    {
        int index1 = Sorting1.GetIndex();

        if (_index == 0 && _needChange == true)
        {
            FullInventory.Instance.ShowInvenItems();
            _needChange = false;
        }
        if (_index == 1 && index1 == 0) // sort by item type ONLY
        {
            FullInventory.Instance.DestroyInvenItems();
            
            // gets all of the items that need sorting
            string[] allItems = FullInventory.Instance.GetAllItems();
            List<string> shortenedItems = new List<string>();
            
            foreach (string item in allItems)
            {
                if (!string.IsNullOrWhiteSpace(item)) // allItems contains many null / whitespace values (all of the empty inventory spaces)
                {
                    shortenedItems.Add(item);
                }
            }

            string[] sortedList = SortItemType(shortenedItems.ToArray());
            FullInventory.Instance.ShowInvenItems(sortedList);
        }
    }
}