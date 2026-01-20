using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SearchItemTitle : MonoBehaviour
{
    public TMP_InputField SearchInputField;

    public void GetEnteredText()
    {
        string text = SearchInputField.text;

        string[] allInvenItems = FullInventory.Instance.GetAllItems();
        List<string> matchingItems = new List<string>();

        foreach (string item in allInvenItems)
        {

            if (!string.IsNullOrWhiteSpace(item))
            {
                text = text.Trim();
                string itemShort = item.Trim();
                if (itemShort.Contains(text, System.StringComparison.OrdinalIgnoreCase))
                {
                    matchingItems.Add(item);
                }
            }
        }

        FullInventory.Instance.DestroyInvenItems();
        FullInventory.Instance.ShowInvenItems(matchingItems.ToArray());
    }
}
