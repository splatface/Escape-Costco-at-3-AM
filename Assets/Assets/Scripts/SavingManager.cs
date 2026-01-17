using UnityEngine;
using System.IO;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Linq;

public class SavingManager : MonoBehaviour
{
    public static SavingManager Instance {get; set;}

    string filePath1 = "save1.txt";
    string filePath2 = "save2.txt";

    public void Save(string filePath)
    {
        // player position
        GameObject PlayerObject = GameObject.FindWithTag("Player");
        Transform playerPos = PlayerObject.transform;

        // current scene
        Scene currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;

        // all items in inventory
        GameObject InventoryObject = GameObject.FindWithTag("Inventory");
        FullInventory Inventory = InventoryObject.GetComponent<FullInventory>();
        string[] allItems = Inventory.GetAllItems();

        // currently equipped items
        GameObject SmallInventoryObject = GameObject.FindWithTag("SmallInventory");
        BarInventory SmallInventory = SmallInventoryObject.GetComponent<BarInventory>();
        string[] equippedItems = SmallInventory.GetCurrentItems();


        #region Saving

        // saving playerPos
        File.WriteAllText(filePath, playerPos.position.ToString()); // clears all by writing
        File.AppendAllText(filePath, playerPos.rotation.ToString()); // adds to it by appending
        File.AppendAllText(filePath, playerPos.localScale.ToString());

        // saving scene
        File.AppendAllText(filePath, currentSceneName);

        // saving currently equipped items
        foreach (string item in allItems)
        {
        File.AppendAllText(filePath, item);
        }

        // saving all items in inventory
        foreach (string item in allItems) // because at very end, know the exact position it starts and ends at
        {
        File.AppendAllText(filePath, item);
        }

        #endregion


    }


    void Awake()
    {
        if (Instance == null) // makes it so that only one exists at a time
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // destroy this would destroy the one we want
        }
    }

    void Update()
    {
        if (Keyboard.current.sKey.wasPressedThisFrame && Keyboard.current.ctrlKey.wasPressedThisFrame) // ctrl+s = save
        {
            Save(filePath1); //STILL NEED TO DO CODE / UI TO SPECIFY WHICH SAVE FILE
        }
    }
}
