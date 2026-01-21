using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Constraints;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InvenSorting1 : MonoBehaviour
{
    public TMP_Dropdown Sorting1;
    public InvenSorting2 Sorting2;
    private int _index = 0;

    private int _indexInteractable;
    private int _indexPowerup;
    private int _indexKeycard;

    private static char[] _alphaOrder = new char[26] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

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

    // alphabetical sorting system
    public List<string> AlphaSort(List<string> sortArray, int startingPos)
    {
        int longestInArray = 0;

        for (int i=0; i<sortArray.Count; i += 1)
        {
            int lengthWord = sortArray[i].Length;

            if (lengthWord > longestInArray)
            {
                longestInArray = lengthWord;
            }
        }

        if (startingPos <= longestInArray)
        {
            for (int initialPosition=0; initialPosition<sortArray.Count; initialPosition += 1)
            {
                int wantedWordPos = initialPosition;
                string initialWord = sortArray[initialPosition];


                for (int comparePosition=initialPosition+1; comparePosition<sortArray.Count; comparePosition += 1)
                {
                    try
                    {
                    char initialLetter = sortArray[initialPosition][0];
                    char compareLetter = sortArray[comparePosition][0];

                    if (sortArray[initialPosition].Length >= startingPos && sortArray[comparePosition].Length >= startingPos)
                    {
                        if (sortArray[initialPosition].Substring(0, startingPos) == sortArray[comparePosition].Substring(0, startingPos))
                        {
                            initialLetter = sortArray[initialPosition][startingPos];
                            compareLetter = sortArray[comparePosition][startingPos];
                        }
                    }

                    initialLetter = char.ToLower(initialLetter);
                    compareLetter = char.ToLower(compareLetter);

                    if (Array.IndexOf(_alphaOrder, compareLetter) < Array.IndexOf(_alphaOrder, initialLetter))
                    {
                        wantedWordPos = comparePosition;
                    }
                    }

                    catch (IndexOutOfRangeException)
                    {
                    }

                }

                sortArray[initialPosition] = sortArray[wantedWordPos];
                sortArray[wantedWordPos] = initialWord;
            }

            
            return AlphaSort(sortArray, startingPos+1);
        }
        else
        {
            return sortArray;
        }
    }

    void Start()
    {
        Sorting1.onValueChanged.AddListener(delegate{ChangeSort(Sorting1);}); // calls this function; not my code
    }


    void Update()
    {
        int index2 = Sorting2.GetIndex(); // get state of the other sorting dropdown menu

        // goes through all of the items and makes the list shorter by getting rid of null and whitespace values
        string[] allItems = FullInventory.Instance.GetAllItems();

        List<string> shortenedItems = new List<string>();
        
        foreach (string item in allItems)
        {
            if (!string.IsNullOrWhiteSpace(item))
            {
                shortenedItems.Add(item);
            }
        }

        // actual sorting part
        if (_index == 0 && _needChange == true)
        {
            FullInventory.Instance.ShowInvenItems();
            _needChange = false;
        }
        else if (_index == 1 && index2 == 0) // alphabetical sorting ONLY
        {
            FullInventory.Instance.DestroyInvenItems();
            allItems = AlphaSort(shortenedItems, 0).ToArray();
            FullInventory.Instance.ShowInvenItems(allItems);
        }
        else if (_index == 1 && index2 == 1) // sorts by type first then by alphabetical within each type
        {
            FullInventory.Instance.DestroyInvenItems();
            string[] sortedItems = Sorting2.SortItemType(shortenedItems.ToArray());

            int foundNum = 0; // 0 = weapons, 1 = interactable, 2 = powerup, 3 = keycard (in order of their placements after going thorugh SortItemType)

            for (int cursor=0; cursor<sortedItems.Length; cursor+=1)
            {
                GameObject item = GameObject.FindWithTag(sortedItems[cursor]);
                ItemBase actualItem = item.GetComponent<ItemBase>();

                string itemType = actualItem.Type.ToLower();

                if (itemType == "interactable" && foundNum == 0)
                {
                    foundNum += 1;
                    _indexInteractable = cursor;
                }
                else if (itemType == "powerup" && foundNum == 1)
                {
                    foundNum += 1;
                    _indexPowerup = cursor;
                }
                else if (itemType == "keycard" && foundNum == 2)
                {
                    foundNum += 1;
                    _indexKeycard = cursor;
                }
            }

            // gives each type its own array to sort through alphabetically before combining them again
            string[] weapons = sortedItems[.._indexInteractable];
            string[] interactableItems = sortedItems[_indexInteractable.._indexPowerup];
            string[] powerups = sortedItems[_indexPowerup.._indexKeycard];
            string[] keycards = sortedItems[_indexKeycard..];

            weapons = AlphaSort(weapons.ToList(), 0).ToArray();
            interactableItems = AlphaSort(interactableItems.ToList(), 0).ToArray();
            powerups = AlphaSort(powerups.ToList(), 0).ToArray();
            keycards = AlphaSort(keycards.ToList(), 0).ToArray();

            List<string> finalList = new List<string>();


            // combine all of the arrays together
            foreach (string weapon in weapons)
            {
                finalList.Add(weapon);
            }
            foreach (string interactableItem in interactableItems)
            {
                finalList.Add(interactableItem);
            }
            foreach (string powerup in powerups)
            {
                finalList.Add(powerup);
            }
            foreach (string keycard in keycards)
            {
                finalList.Add(keycard);
            }

            FullInventory.Instance.ShowInvenItems(finalList.ToArray()); // show the sorted items
        }
    }
}
