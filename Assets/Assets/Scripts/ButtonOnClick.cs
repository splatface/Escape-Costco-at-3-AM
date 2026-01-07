using UnityEngine;

public class ButtonClick : MonoBehaviour
{

    public FullInventory FullInventory;

    void OnClick()
    {
        ItemBaseClass item = FullInventory.GetCurrentItem();

        if (item.GetItemType() == "weapon")
        {
            
        }
        else if (item.GetItemType() == "interactable")
        {
            
        }
        else if (item.GetItemType() == "powerup")
        {
            
        }
        //equip item into 4 slots based on type
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
