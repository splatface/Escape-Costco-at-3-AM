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
    private string[] _itemsInside = new string[30]; // array of all items in the inventory as their tags
    private int _nextPosition = 0; // cursor in array
    private float _boxSideLength = 1.5f; // (PLACEHOLDER FOR NOW! CHECK LENGTH)
    private ItemBaseClass _currentItem;
    public ItemSpawner Spawner;



    //text objects for the item when clicked
    public TMP_Text ItemTitle;
    public TMP_Text ItemDescrip;


    //what happens when the item needs to go into the full inventory
    public void PlaceIntoInven(string tag)
    {
        _itemsInside[_nextPosition] = tag;
        _nextPosition += 1;
    }

    // what happens when the inventory is revealed onto the screen
    public void ShowInvenItems()
    {
        float startingLength = -3.5f;
        float endingLength = startingLength+5*_boxSideLength;
        float y = 3f;
        float x = startingLength;
        Debug.Log("endingLength:" + endingLength);

        for (int cursor=0; cursor<_nextPosition; cursor += 1)
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
            Debug.Log("c:" + cursor);
            Debug.Log("x:" + x);
            Debug.Log("");

            Vector3 position = new Vector3 (x,y);

            Spawner.SpawnItem(_itemsInside[cursor], position);
        }
    }

    public void DestroyInvenItems()
    {
        for (int cursor=0; cursor<_nextPosition; cursor += 1)
        {
            tag = _itemsInside[cursor];

            GameObject item = GameObject.FindWithTag(tag);
            DestroyImmediate(item);
        }
    }

    // what happens when you click on an item in the inventory
    public void OnClickItem(int itemNumber) // pass in the index
    {
        string itemTag = _itemsInside[itemNumber];
        GameObject itemObject = GameObject.FindWithTag(itemTag);
        ItemBaseClass item = itemObject.GetComponent<ItemBaseClass>();

        //updates the item's text
        ItemTitle.text = item.Name;
        ItemDescrip.text = item.Description;
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
    }

    void Update()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            PlaceIntoInven("Milk");
        }

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
                DestroyInvenItems();
            }
        }
    }
}
