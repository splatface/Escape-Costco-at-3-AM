using TMPro;
using UnityEngine;

//script includes: logic behind placing items into the correct box for the full inventory screen
public class PlaceItemInvenFull : MonoBehaviour
{

    private int _lengthRow = 6; // for putting the images on the screen

    private SpriteRenderer[] _itemsInside = new SpriteRenderer[30]; // array maxes at visual capacity of inventory full

    private int _lastPosition = 0; // cursor in array

    private float _boxSideLength = 1f; // (PLACEHOLDER FOR NOW! CHECK LENGTH)

    //text objects for the item when clicked
    public TextMeshPro ItemTitle;
    public TextMeshPro ItemDescrip;

    //called by another class when an item is picked up
    public void PickedUpItem(SpriteRenderer itemName)
    {
        _itemsInside[_lastPosition] = itemName; // SpriteRenderer type so can actually put on screen
        _lastPosition += 1;
    }

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

    public void OnClickItem(ItemBaseClass item)
    {
        string name = item.GetName();
        string descrip = item.GetDescription();

        //updates the item's text
        ItemTitle.text = name;
        ItemDescrip.text = descrip;
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
