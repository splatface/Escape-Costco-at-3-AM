using UnityEngine;
using System.IO;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Linq;

public class SavingManager : MonoBehaviour
{
    // variables that need saving
    public Vector3 playerPos;
    public string currentSceneName;
    public string[] allPossessedItems;
    public string[] allEquippedItems;

    // for singleton
    public static SavingManager Instance {get; set;}

    // for showing the inventory
    public SpriteRenderer Renderer;
    private bool _isOpen = false;

    // file paths
    string filePath1 = Path.Combine(Application.persistentDataPath, "save1.json"); // saves to a specific folder that Unity always knows where to find
    string filePath2 = Path.Combine(Application.persistentDataPath, "save2.json");

    public void Save(int buttonNum)
    {
        string path;

        if (buttonNum == 0) // chooses the right file
        {
            path = filePath1;
        }
        else
        {
            path = filePath2;
        }


        #region Getting Proper Info

        // player position
        GameObject PlayerObject = GameObject.FindWithTag("Player");
        Transform playerPos = PlayerObject.transform;

        // current scene
        Scene currentScene = SceneManager.GetActiveScene();

        // all items in inventory
        GameObject InventoryObject = GameObject.FindWithTag("Inventory");
        FullInventory Inventory = InventoryObject.GetComponent<FullInventory>();
        string[] allItems = Inventory.GetAllItems();

        // currently equipped items
        GameObject SmallInventoryObject = GameObject.FindWithTag("SmallInventory");
        BarInventory SmallInventory = SmallInventoryObject.GetComponent<BarInventory>();
        string[] equippedItems = SmallInventory.GetCurrentItems();

        #endregion


        // not my code
        SavingManager data = new SavingManager() // makes new SavingmManager and saves the data to it for easy writing
        {
            playerPos = playerPos.position,
            currentSceneName = currentScene.name,
            allEquippedItems = equippedItems,
            allPossessedItems = allItems
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
        // now mine again

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
            Renderer.sortingLayerName = "ShowInventory";
        }
        if (Keyboard.current.escapeKey.wasPressedThisFrame && _isOpen == true)
        {
            _isOpen = false;
            Renderer.sortingLayerName = "HideInventory";
        }
    }
}
