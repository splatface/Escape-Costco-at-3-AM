using System;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemBase : MonoBehaviour
{
    //properties of item
    public string Name = "";
    public string Description = "";
    public string Type = "";
    public Rigidbody2D Item;

    //extra needed for equipping
    public PlayerMovement Player;
    public Canvas Renderer;

    public virtual void UseItem()
    {
        Debug.Log("used");
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
            Renderer.sortingLayerName = "ShowInventory";

            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                FullInventory.Instance.PlaceIntoInven(tag);
            }
        }
        else
        {
            Renderer.sortingLayerName = "HideInventory";
        }

    }
}
