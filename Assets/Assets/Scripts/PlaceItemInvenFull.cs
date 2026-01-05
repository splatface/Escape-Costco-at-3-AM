using UnityEngine;

public class PlaceItemInvenFull : MonoBehaviour
{

    private int _lengthRow = 6; // for putting the images on the screen

    private SpriteRenderer[] _itemsInside = new SpriteRenderer[30]; // array maxes at visual capacity of inventory full

    private int _lastPosition = 0; // cursor in array

    private float _boxSideLength = 1f; // the length of the side of the box in the inventory (PLACEHOLDER FOR NOW!)

    public void PickedUpItem(SpriteRenderer itemName)
    {
        _itemsInside[_lastPosition] = itemName; // SpriteRenderer type so can actually put on screen
        _lastPosition += 1;
    }

    public void PlaceIntoInven()
    {
        for (int cursor=1; cursor<_lastPosition; cursor += 1)
        {

            // not sure on this logic yet; CHECK
            float x_position = cursor%_lengthRow;
            float y_position = cursor/_lengthRow * _boxSideLength;
            
            //change items vector position using variable from their class
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
