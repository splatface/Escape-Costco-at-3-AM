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
    public Rigidbody2D RigidBody;

    //extra needed for equipping
    public PlayerMovement Player;
    public Canvas Renderer;

    public virtual void UseItem()
    {
    }
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // GameObject playerBase = GameObject.FindWithTag("Player");
        // Player = playerBase.GetComponent<PlayerMovement>();

        // ItemBase[] item = GameObject.FindObjectsByType<ItemBase>(FindObjectsSortMode.None); // find all items in the scene

        // foreach (ItemBase eachItem in item)
        // {
        //     Rigidbody2D itemRb = eachItem.GetComponent<Rigidbody2D>();

        //     if (itemRb != null)
        //     {
        //         itemRb.position = transform.position;

        //         Vector3 playerPosition = Player.GetCurrentPosition();

        //         float x = playerPosition.x - itemRb.position.x;
        //         float y = playerPosition.y - itemRb.position.y;

        //         float distance = Mathf.Sqrt((float)(Math.Pow(x,2) + Math.Pow(y,2))); //change to calculate the distance between the player and the item

        //         if (distance <= 2f)
        //         {
        //             Renderer.sortingLayerName = "ShowInventory";

        //             if (Keyboard.current.eKey.wasPressedThisFrame)
        //             {
        //                 FullInventory.Instance.PlaceIntoInven(tag);
        //             }
        //         }
        //         else
        //         {
        //             Renderer.sortingLayerName = "HideInventory";
        //         }
        //     }
            
        // }

    }
}
