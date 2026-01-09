using UnityEngine;

//script includes: the inventory bar shows or hides itself 
public class BarInventory : MonoBehaviour
{
    //variables for state of inventory
    public FullInventory InventoryFull;
    public SpriteRenderer InventoryBar;
    private bool _showState;

    //variables for putting items into inventory / current items in inventory
    private ItemBaseClass[] _currentItems = new ItemBaseClass[4];

    public void PlaceIntoInven(ItemBaseClass item)
    {
        float newX = 0;
        float newY = 0;
        if (item.Type == "weapon")
        {
            _currentItems[0] = item;
            //change values of newX and newY here (and for all of the others) 
        }
        else if (item.Type == "interactable")
        {
            _currentItems[1] = item;
        }
        else if (item.Type == "keycard")
        {
            _currentItems[2] = item;
        }
        else if (item.Type == "powerup")
        {
            _currentItems[3] = item;
        }

        for (int cursor=0; cursor<4; cursor += 1)
        {
            if (_currentItems[cursor] != null)
            {
                item.MoveItem(newX, newY);
            }
        }
    }
    
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
