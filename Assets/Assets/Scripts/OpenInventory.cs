
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenInventory : MonoBehaviour
{
    public SpriteRenderer InventoryBox;

    private static bool _isOpen = false;


    // returns whether the inventory box is open or not
    public bool GetOpenState()
    {
        return _isOpen;
    }

    void Start()
    {
        
    }

    void Update()
    {

        if (Keyboard.current.iKey.wasPressedThisFrame)
        {

            if (_isOpen == false)
            {
                InventoryBox.sortingLayerName = "ShowInventory";
                _isOpen = true;
            }
            else
            {
                InventoryBox.sortingLayerName = "HideInventory";                
                _isOpen = false;
            }
        }
    }
}
