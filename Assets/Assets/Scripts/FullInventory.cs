using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

//script includes: logic behind placing items into the correct box for the full inventory screen
public class FullInventory : MonoBehaviour
{
    //variables for showing the inventory
    public SpriteRenderer InventoryBox;
    private static bool _isOpen = false;
    private int _lengthRow = 6; // for putting the images on the screen


    //variables for storing items in the inventory
    private ItemBaseClass[] _itemsInside = new ItemBaseClass[30]; // array of all items in the inventory
    private int _nextPosition = 0; // cursor in array
    private float _boxSideLength = 1f; // (PLACEHOLDER FOR NOW! CHECK LENGTH)
    private ItemBaseClass _currentItem;
    public ItemSpawner Spawner;



    //text objects for the item when clicked
    public TMP_Text ItemTitle;
    public TMP_Text ItemDescrip;


    //what happens when the item needs to go into the full inventory
    public void PlaceIntoInven(string tag)
    {
        Debug.Log(tag);
        GameObject itemObject = GameObject.FindWithTag(tag);
        ItemBaseClass item = itemObject.GetComponent<ItemBaseClass>(); // "converts" it to ItemBaseClass type for usage

        _itemsInside[_nextPosition] = item;
        _nextPosition += 1;
        Debug.Log(item);
    }

    // what happens when the inventory is revealed onto the screen
    public void ShowInvenItems()
    {
        for (int cursor=0; cursor<_nextPosition; cursor += 1)
        {
            // not sure on this logic yet; CHECK
            float x = cursor%_lengthRow;
            float y = cursor/_lengthRow * _boxSideLength;
            Vector3 position = new Vector3 (x,y);

            Spawner.SpawnItem(_itemsInside[cursor].tag, position);
        }
    }

    // what happens when you click on an item in the inventory
    public void OnClickItem(int itemNumber) // pass in the index
    {
        ItemBaseClass item = _itemsInside[itemNumber];
        string tag = item.tag;

        GameObject itemObject = GameObject.FindWithTag(tag);
        item = itemObject.GetComponent<ItemBaseClass>();

        _currentItem = item;
        string name = item.Name;
        string descrip = item.Description;

        //updates the item's text
        ItemTitle.text = name;
        ItemDescrip.text = descrip;
    }


    //getters for encapsulation
    public ItemBaseClass GetCurrentItem()
    {
        return _currentItem;
    }

    public bool GetOpenState()
    {
        return _isOpen;
    }


    void Start()
    {
        PlaceIntoInven("Milk"); // for testing purposes; remove in actual
    }

    void Update()
    {
        //changes state of whether inventory is shown or not
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {

            if (_isOpen == false)
            {
                InventoryBox.sortingLayerName = "ShowInventory";
                _isOpen = true;
                ShowInvenItems();
            }
            else
            {
                InventoryBox.sortingLayerName = "HideInventory";                
                _isOpen = false;
            }
        }
    }
}
