using System;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemBaseClass : MonoBehaviour
{
    //properties of item
    public string Name = "";
    public string Description = "";
    public string Type = "";
    public SpriteRenderer _renderer;
    public Rigidbody2D Item;

    //extra needed for equipping
    public PlayerMovement Player;
    public FullInventory Inventory;

    // temporary; may change
    public void MoveItem(float newX, float newY)
    {
        transform.position = new Vector3 (newX, newY, 0);
    }

    public void EquipItem(ItemBaseClass item)
    {
    }
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        Item = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Item.position = transform.position;

        Vector3 playerPosition = Player.GetCurrentPosition();

        float x = playerPosition.x - Item.position.x;
        float y = playerPosition.y - Item.position.y;

        float distance = Mathf.Sqrt((float)(Math.Pow(x,2) + Math.Pow(y,2))); //change to calculate the distance between the player and the item

        if (distance <= 5)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                Inventory.PlaceIntoInven(this);
            }
        }

    }
}
