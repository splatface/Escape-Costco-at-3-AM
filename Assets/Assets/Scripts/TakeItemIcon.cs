using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class TakeItemIcon : MonoBehaviour
{
    public PlayerMovement Player;
    public Canvas Renderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FullInventory.Instance.GetOpenState() == false) // will only check if you can get items when the inventory is not open
        {
            GameObject playerBase = GameObject.FindWithTag("Player");
            Player = playerBase.GetComponent<PlayerMovement>();

            ItemBase[] item = GameObject.FindObjectsByType<ItemBase>(FindObjectsSortMode.None); // find all items in the scene

            foreach (ItemBase eachItem in item) // if didn't make sure the inventory was closed, it would also go through the inventory items
            {
                string[] currentlyEquippedItems = BarInventory.Instance.GetCurrentItems();

                if (currentlyEquippedItems.Contains(eachItem.tag) == false) // if the item it looks at is not one in the bar inventory
                {
                    Rigidbody2D itemRb = eachItem.GetComponent<Rigidbody2D>();

                    if (itemRb != null)
                    {
                        itemRb.position = transform.position;

                        Vector3 playerPosition = Player.GetCurrentPosition();

                        float x = playerPosition.x - itemRb.position.x;
                        float y = playerPosition.y - itemRb.position.y;

                        float distance = Mathf.Sqrt((float)(Math.Pow(x,2) + Math.Pow(y,2))); //change to calculate the distance between the player and the item

                        if (distance <= 2f)
                        {
                            Renderer.sortingLayerName = "ShowInventory";

                            if (Keyboard.current.eKey.wasPressedThisFrame)
                            {
                                FullInventory.Instance.PlaceIntoInven(eachItem.tag);
                            }
                        }
                        else
                        {
                            Renderer.sortingLayerName = "HideInventory";
                        }
                    }
                    
                }
                
            }
        }
    }
}
