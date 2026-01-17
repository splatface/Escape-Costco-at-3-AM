using UnityEngine;

//script includes: the inventory bar shows or hides itself 
public class BarInventory : MonoBehaviour
{
    //variables for state of inventory
    public SpriteRenderer InventoryBarRenderer;
    private bool _showState;

    //variables for putting items into inventory / current items in inventory
    private string[] _currentItems = new string[4];
    private float _itemSpacing = 1.5f;
    public ItemSpawner Spawner;
    private GameObject[] _previousObjectList;
    private GameObject[] SpawnedObjects = new GameObject[4];
    
    public static BarInventory Instance {get; set;}

    public void PlaceIntoInven(string itemTag)
    {
        GameObject itemObject = GameObject.FindWithTag(itemTag);
        ItemBaseClass item = itemObject.GetComponent<ItemBaseClass>();
        string type = item.Type;
        float newX = 3.7f;
        float newY = -3.7f;
        int index = 0;
        
        GameObject[] pastItemObject = new GameObject[4];

        for (int itemNum = 0; itemNum<4; itemNum+=1) //to copy over the info and not the location
        {
            pastItemObject[itemNum] = SpawnedObjects[itemNum];
        }

        if (type == "weapon")
        {
            _currentItems[0] = itemTag;
            index = 0;
        }
        else if (type == "interactable")
        {
            _currentItems[1] = itemTag;
            newX += _itemSpacing;
            index = 1;
        }
        else if (type == "keycard")
        {
            _currentItems[2] = itemTag;
            newX += 2*_itemSpacing;
            index = 2;
        }
        else if (type == "powerup")
        {
            _currentItems[3] = itemTag;
            newX += 3*_itemSpacing;
            index = 3;
        }
        Vector3 position = new Vector3 (newX, newY);

        SpawnedObjects[index] = Spawner.SpawnItem(item.tag, position);

        if (pastItemObject[index] != null)
        {
            Destroy(pastItemObject[index]); // destroys previous sprite at that specific location
        }
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

    
    // singleton logic so will always exist
    void Awake()
    {
        if (Instance == null) // makes it so that only one exists at a time
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // destroy this would destroy the one we want
        }
    }

    void Update()
    {

        //changes state of bar inventory
        _showState = FullInventory.Instance.GetOpenState();

        if (_showState == false) // if the full inventory is NOT being shown
        {
            InventoryBarRenderer.sortingLayerName = "ShowInventory";
            ShowItems();
        }
        else
        {
            InventoryBarRenderer.sortingLayerName = "HideInventory";
        }

    }
}
