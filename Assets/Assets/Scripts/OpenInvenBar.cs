using UnityEngine;

//script includes: the inventory bar shows or hides itself 
public class InvenBarState : MonoBehaviour
{

    public InvenFullState InventoryFull;

    public SpriteRenderer InventoryBar;

    private bool _showState;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
