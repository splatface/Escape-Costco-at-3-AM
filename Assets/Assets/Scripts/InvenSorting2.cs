using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InvenSorting2 : MonoBehaviour
{
    public TMP_Dropdown Sorting2;
    private int _index = 0;

    private bool _needChange = false;
    public void ChangeSort(TMP_Dropdown newSort)
    {
        _index = newSort.value;
        _needChange = true;
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
            string itemType = actualItem.Type;

            if (itemType == "weapon")
            {
                weaponTags.Add(tag);
            }
            else if (itemType == "interactable")
            {
                interactableItemTags.Add(tag);
            }
            else if (itemType == "powerups")
            {
                powerupTags.Add(tag);
            }
            else
            {
                keycardTags.Add(tag);
            }
        }

        // assembling all of the items into one final list
        List<string> finalArray = new List<string>();

        foreach (string weapon in weaponTags)
        {
            finalArray.Add(weapon);
        }
        foreach (string interactableItem in interactableItemTags)
        {
            finalArray.Add(interactableItem);
        }
        foreach (string powerup in powerupTags)
        {
            finalArray.Add(powerup);
        }
        foreach (string keycard in keycardTags)
        {
            finalArray.Add(keycard);
        }

        return finalArray.ToArray(); // return + change list to array
    }
    
    void Start()
    {
        Sorting2.onValueChanged.AddListener(delegate{ChangeSort(Sorting2);}); // calls this function; not my code
    }


    void Update()
    {
        if (_index == 0 && _needChange == true)
        {
            FullInventory.Instance.ShowInvenItems();
            _needChange = false;
        }
        else if (_index == 1) // item type
        {
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