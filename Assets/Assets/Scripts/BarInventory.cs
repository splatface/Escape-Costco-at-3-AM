using UnityEngine;

//script includes: the inventory bar shows or hides itself 
public class BarInventory : MonoBehaviour
{
    //variables for state of inventory
    public FullInventory InventoryFull;

    public SpriteRenderer InventoryBar;

    private bool _showState;
    
    void Start()
    {
        
    }

    void Update()
    {

        //changes state of bar inventory
        _showState = InventoryFull.GetOpenState();

        if (_showState == false) // if the full inventory is NOT being shown
        {
            InventoryBar.sortingLayerName = "ShowInventory";
        }
        else
        {
            InventoryBar.sortingLayerName = "HideInventory";
        }

    }
}
