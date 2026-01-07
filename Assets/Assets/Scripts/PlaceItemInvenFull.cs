using TMPro;
using UnityEngine;
using UnityEngine.UI;

//script includes: logic behind placing items into the correct box for the full inventory screen
public class FullInventoryLogic : MonoBehaviour
{

    private int _lengthRow = 6; // for putting the images on the screen

    private ItemBaseClass[] _itemsInside = new ItemBaseClass[30]; // array of all items in the inventory

    private int _lastPosition = 0; // cursor in array

    private float _boxSideLength = 1f; // (PLACEHOLDER FOR NOW! CHECK LENGTH)

    //text objects for the item when clicked
    public TextMeshPro ItemTitle;
    public TextMeshPro ItemDescrip;
    public Button EquipButton;

    private ItemBaseClass _currentItem;

    //what happens when the item needs to go into the full inventory
    public void PlaceIntoInven(ItemBaseClass item)
    {
        for (int cursor=1; cursor<_lastPosition; cursor += 1)
        {

            // not sure on this logic yet; CHECK
            float x_position = cursor%_lengthRow;
            float y_position = cursor/_lengthRow * _boxSideLength;

            item.MoveItem(x_position, y_position);
        }
    }

    public void OnClickItem(int itemNumber) // pass in the index
    {
        ItemBaseClass item = _itemsInside[itemNumber];
        _currentItem = item;
        string name = item.GetName();
        string descrip = item.GetDescription();

        //updates the item's text
        ItemTitle.text = name;
        ItemDescrip.text = descrip;
    }

    public ItemBaseClass GetCurrentItem()
    {
        return _currentItem;
    }




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ItemTitle = GetComponent<TextMeshPro>();
        ItemDescrip = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
