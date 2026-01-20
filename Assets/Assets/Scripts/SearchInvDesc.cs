using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class SearchInvDesc : MonoBehaviour
{
    public TMP_InputField SearchInput;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetText()
    {
        string text = SearchInput.text;
        string[] inventoryItems = FullInventory.Instance.GetAllItems();
        // search descriptions in inventory and create an array of appropriate size 
        int size = 0; 
        foreach (string item in inventoryItems)
        {
            GameObject itemObject = GameObject.FindWithTag(item);
            ItemBase itemInfo = itemObject.GetComponent<ItemBase>();
            string itemDesc = itemInfo.Description;

            if (string.IsNullOrEmpty(item) == false)
            {
                string textMod = text.ToLower();
                string itemDescMod = itemDesc.ToLower();
                if (itemDescMod.Contains(textMod))
                {
                    size++;
                }
            }
        }
        // add items matching search to new array 
        string[] itemsToShow = new string[size];
        int cursor = 0;
        for (int i = 0; i < size; i++)
        {
            GameObject itemObject = GameObject.FindWithTag(inventoryItems[i]);
            ItemBase itemInfo = itemObject.GetComponent<ItemBase>();
            string itemDesc = itemInfo.Description;
            if (string.IsNullOrEmpty(inventoryItems[i]) == false)
            {
                string textMod = text.ToLower();
                string itemDescMod = itemDesc.ToLower(); 
                if (itemDescMod.Contains(textMod))
                {
                    itemsToShow[cursor] = inventoryItems[i];
                    cursor++; 
                }
            }
        }
        FullInventory.Instance.DestroyInvenItems();
        FullInventory.Instance.ShowInvenItems(itemsToShow);
    }
}
