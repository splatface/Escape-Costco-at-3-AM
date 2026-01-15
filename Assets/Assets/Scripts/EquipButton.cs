using UnityEngine;

public class EquipButton : MonoBehaviour
{

    public FullInventory FullInventory;

    public BarInventory BarInventory;

    public void OnClick()
    {
        ItemBaseClass item = FullInventory.GetCurrentItem();
        BarInventory.PlaceIntoInven(item.tag);
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
