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
    private int _index = 0;

    private static char[] _alphaOrder = new char[26] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

    private bool _needChange = false;
    public void ChangeSort(TMP_Dropdown newSort)
    {
        _index = newSort.value;
        _needChange = true;
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
        if (_index == 0 && _needChange == true)
        {
            FullInventory.Instance.ShowInvenItems();
            _needChange = false;
        }
        else if (_index == 1) //alphabetical sorting
        {
            FullInventory.Instance.DestroyInvenItems();
            string[] allItems = FullInventory.Instance.GetAllItems();

            List<string> shortenedItems = new List<string>();
            
            foreach (string item in allItems)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    shortenedItems.Add(item);
                }
            }

            allItems = AlphaSort(shortenedItems, 0).ToArray();
            FullInventory.Instance.ShowInvenItems(allItems);
        }
    }
}
