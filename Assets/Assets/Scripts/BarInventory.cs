using UnityEngine;

//script includes: the inventory bar shows or hides itself 
public class BarInventory : MonoBehaviour
{
    //variables for state of inventory
    public FullInventory InventoryFull;
    public SpriteRenderer InventoryBar;
    private bool _showState;

    //variables for putting items into inventory / current items in inventory
    private string[] _currentItems = new string[4];
    private float _itemSpacing = 1.5f;
    public ItemSpawner Spawner;

    public void PlaceIntoInven(string itemTag)
    {
        GameObject itemObject = GameObject.FindWithTag(itemTag);
        ItemBaseClass item = itemObject.GetComponent<ItemBaseClass>();
        string type = item.Type;
        float newX = 3.7f;
        float newY = -3.7f;

        if (type == "weapon")
        {
            _currentItems[0] = itemTag;
        }
        else if (type == "interactable")
        {
            _currentItems[1] = itemTag;
            newX += _itemSpacing;
        }
        else if (type == "keycard")
        {
            _currentItems[2] = itemTag;
            newX += 2*_itemSpacing;
        }
        else if (type == "powerup")
        {
            _currentItems[3] = itemTag;
            newX += 3*_itemSpacing;
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
                GameObject itemName = GameObject.FindWithTag(_currentItems[cursor]);
                SpriteRenderer renderer = itemName.GetComponent<SpriteRenderer>();
                
                renderer.sortingLayerName = "ShowInventory";
                
            }
        }
    }

    public string[] GetCurrentItems()
    {
        return _currentItems;
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
