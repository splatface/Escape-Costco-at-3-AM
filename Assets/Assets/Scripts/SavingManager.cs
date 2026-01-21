using UnityEngine;
using System.IO;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class SavingManager : MonoBehaviour
{
    // variables that need saving (public for loading)


    // showing Saved! icon
    public Canvas SavedIconRenderer;

    // for singleton
    public static SavingManager Instance {get; set;}

    // for showing the inventory
    public Canvas ScreenRenderer;
    private bool _isOpen = false;

    // file paths
    private string _filePath1;
    private string _filePath2;

    public void Save(int buttonNum)
    {
        string path;

        if (buttonNum == 0) // chooses the right file
        {
            path = _filePath1;
        }
        else
        {
            path = _filePath2;
        }


        #region Getting Proper Info

        // player position
        GameObject PlayerObject = GameObject.FindWithTag("Player");
        Transform playerPos = PlayerObject.transform;

        // current scene
        Scene currentScene = SceneManager.GetActiveScene();

        // all items in inventory
        // string[] allItems = FullInventory.Instance.GetAllItems();

        // // currently equipped items
        // string[] equippedItems = BarInventory.Instance.GetCurrentItems();

        #endregion


        // not my code
        SavedData data = new SavedData() // makes new SavingmManager and saves the data to it for easy writing
        {
            playerPos = playerPos.position,
            currentSceneName = currentScene.name
            // allEquippedItems = equippedItems,
            // allPossessedItems = allItems
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
        // now mine again

        // for displaying and hiding the saving icon
        StartSavedIconCoroutine();

    }

    IEnumerator DisplaySavedIcon()
    {
        SavedIconRenderer.sortingLayerName = "ShowInventory";
        yield return new WaitForSeconds(2f);
        SavedIconRenderer.sortingLayerName = "HideInventory";
    }

    public void StartSavedIconCoroutine()
    {
        StartCoroutine(DisplaySavedIcon());
    }



    void Awake()
    {
        _filePath1 = Path.Combine(Application.persistentDataPath, "save1.json"); // saves to a specific folder that Unity always knows where to find
        _filePath2 = Path.Combine(Application.persistentDataPath, "save2.json");

        if (Instance == null) // makes it so that only one exists at a time
        {
            Instance = this;
            DontDestroyOnLoad(transform.root.gameObject);
        }
        else
        {
            Destroy(transform.root.gameObject); // destroy this would destroy the one we want
        }
    }

    void Update()
    {
        if (Keyboard.current.shiftKey.wasPressedThisFrame && _isOpen == false) // ctrl+s = save
        {
            ScreenRenderer.sortingLayerName = "ShowInventory";
            Debug.Log("showing");
            _isOpen = true;
        }
        if (Keyboard.current.escapeKey.wasPressedThisFrame && _isOpen == true)
        {
            _isOpen = false;
            ScreenRenderer.sortingLayerName = "HideInventory";
            Debug.Log("hiding");
        }
    }
}
