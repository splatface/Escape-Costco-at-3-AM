using UnityEngine;

//script includes: the inventory bar shows or hides itself 
public class BarInventory : MonoBehaviour
{
    //variables for state of inventory
    public FullInventory InventoryFull;
    public SpriteRenderer InventoryBar;
    private bool _showState;

    public MilkItem Milk;

    //variables for putting items into inventory / current items in inventory
    private ItemBaseClass[] _currentItems = new ItemBaseClass[4];

    public void PlaceIntoInven(ItemBaseClass item)
    {
        string type = item.Type;
        float newX = 0;
        float newY = 0;
        Debug.Log(type);
        Debug.Log(item.Type);

        if (type == "weapon")
        {
            _currentItems[0] = item;
            //change values of newX and newY here (and for all of the others) 
        }
        else if (type == "interactable")
        {
            _currentItems[1] = item;
            newX = 1;
            newY = 1;
        }
        else if (type == "keycard")
        {
            _currentItems[2] = item;
        }
        else if (type == "powerup")
        {
            _currentItems[3] = item;
        }

        item.MoveItem(newX, newY);
    }
    
    void Start()
    {
    }

    void Awake()
    {
        //PlaceIntoInven(Milk);
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
