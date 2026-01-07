using UnityEngine;

public class ButtonClick : MonoBehaviour
{

    public FullInventory FullInventory;

    void OnClick()
    {
        ItemBaseClass item = FullInventory.GetCurrentItem();

        if (item.Type == "weapon")
        {
            
        }
        else if (item.Type == "interactable")
        {
            
        }
        else if (item.Type == "powerup")
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
