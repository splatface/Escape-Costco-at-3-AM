using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Linq;

//script includes: logic behind placing items into the correct box for the full inventory screen
public class FullInventory : MonoBehaviour
{
    //variables for showing the inventory
    public SpriteRenderer InventoryRenderer;
    private static bool _isOpen = false;
    private int _lengthRow = 6; // for putting the images on the screen
    public Canvas DropdownCanvas;


    //variables for storing items in the inventory
    private string[] _itemsInside = new string[30]; // array of all items in the inventory as their tags
    private int _nextPosition = 0; // cursor in array
    private float _boxSideLength = 1.5f; // (PLACEHOLDER FOR NOW! CHECK LENGTH)
    private ItemBase _currentItem;
    public ItemSpawner Spawner;



    //text objects for the item when clicked
    public TMP_Text ItemTitle;
    public TMP_Text ItemDescrip;
    public Canvas TextRender;

    public static FullInventory Instance {get; set;}


    //what happens when the item needs to go into the full inventory
    public void PlaceIntoInven(string itemTag)
    {
        _itemsInside[_nextPosition] = itemTag;
        _nextPosition += 1;
    }

    // what happens when the inventory is revealed onto the screen
    public void ShowInvenItems(string[] itemsTag=null)
    {
        float startingLength = -3.5f;
        float endingLength = startingLength+(_lengthRow-1)*_boxSideLength;
        float y = 3f;
        float x = startingLength;
        int lastPosition;

        if (itemsTag != null)
        {
            lastPosition = itemsTag.Length;
        }
        else
        {
            lastPosition = _nextPosition;
        }

        for (int cursor=0; cursor<lastPosition; cursor += 1)
        {
            if (x<=endingLength)
            {
            x += _boxSideLength; // moves to the next box
            }
            else
            {
                x=startingLength+_boxSideLength; // sets it back to the first box on the left
                y-=_boxSideLength; // moves position one row down
            }

            Vector3 position = new Vector3 (x,y);

            if (itemsTag != null) // if argument given
            {
                Spawner.SpawnItem(itemsTag[cursor], position); // goes based off of the sorted list
            }
            else
            {
                Spawner.SpawnItem(_itemsInside[cursor], position); // goes based off unsorted list
            }

        }
    }

    public void DestroyInvenItems()
    {
        for (int cursor=0; cursor<_nextPosition; cursor += 1)
        {
            string itemTag = _itemsInside[cursor];

            if (BarInventory.Instance.GetCurrentItems().Contains(itemTag)) // assumes will only have 1 of each item at a time
            {
                continue; //goes onto next item
            }
            GameObject[] items = GameObject.FindGameObjectsWithTag(itemTag);

            for (int itemNum=0; itemNum<items.Length; itemNum += 1)
            {
                Destroy(items[itemNum]);
                
            }

        }
    }

    // what happens when you click on an item in the inventory
    public void OnClickItem(int itemNumber) // pass in the index
    {
        string itemTag = _itemsInside[itemNumber];
        GameObject itemObject = GameObject.FindWithTag(itemTag);
        ItemBase item = itemObject.GetComponent<ItemBase>();
        _currentItem = item;

        //updates the item's text
        ItemTitle.text = itemTag;
        ItemDescrip.text = item.Description;
    }

    public string[] GetAllItems()
    {
        return _itemsInside;
    }

    public void SetAllItems(string[] allItems)
    {
        _itemsInside = allItems;
    }

    //getters for encapsulation
    public ItemBase GetCurrentItem()
    {
        return _currentItem;
    }

    public bool GetOpenState()
    {
        return _isOpen;
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
            Destroy(gameObject); // destroy(this) would destroy the one we want
        }
    }

    void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            PlaceIntoInven("Milk");
        }
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            PlaceIntoInven("Banana");
        }

        //changes state of whether inventory is shown or not
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {

            if (_isOpen == false)
            {
                InventoryRenderer.sortingLayerName = "ShowInventory";
                InventoryRenderer.sortingOrder = 0;
                _isOpen = true;
                ShowInvenItems();
                TextRender.sortingLayerName = "Text";
                DropdownCanvas.sortingLayerName = "ShowInventory";
                TextRender.sortingOrder = 10;
                DropdownCanvas.sortingOrder = 10;
            }
            else
            {
                InventoryRenderer.sortingLayerName = "HideInventory";                
                _isOpen = false;
                DestroyInvenItems();
                TextRender.sortingLayerName = "HideInventory";
                DropdownCanvas.sortingLayerName = "HideInventory";
            }
        }
    }
}
