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
    private float _itemSpacing = 0.5f;
    public ItemSpawner Spawner;

    public void PlaceIntoInven(ItemBaseClass item)
    {
        string type = item.Type;
        float newX = 0f;
        float newY = 0f;

        if (type == "weapon")
        {
            _currentItems[0] = item;
            //change values of newX and newY here (and for all of the others) 
        }
        else if (type == "interactable")
        {
            _currentItems[1] = item;
            newX = 3.5f;
            newY = -3f;
        }
        else if (type == "keycard")
        {
            _currentItems[2] = item;
        }
        else if (type == "powerup")
        {
            _currentItems[3] = item;
        }

        Vector3 position = new Vector3 (newX, newY);

        Spawner.SpawnItem(item.tag, position);
    }

    public void ShowItems()
    {
        for (int cursor=0; cursor<4; cursor += 1)
        {
            if (_currentItems[cursor] != null)
            {
                GameObject itemName = GameObject.FindWithTag(_currentItems[cursor].Name);
                SpriteRenderer renderer = itemName.GetComponent<SpriteRenderer>();
                
                renderer.sortingLayerName = "ShowInventory";
                
            }
        }
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
            ShowItems();
        }
        else
        {
            InventoryBar.sortingLayerName = "HideInventory";
        }

    }
}
