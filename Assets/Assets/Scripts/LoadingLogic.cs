using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadingLogic : MonoBehaviour
{

    private string _filePath1; 
    private string _filePath2;

    public void Load(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError("Save file not found: " + filePath);
            return;
        }

        string lines = File.ReadAllText(filePath);

        SavedData data = JsonUtility.FromJson<SavedData>(lines);

        #region Loading Data Logic

        // player stuff; need Instance to get
        // FullInventory.Instance.SetAllItems(data.allPossessedItems);
        // BarInventory.Instance.SetEquippedItems(data.allEquippedItems);
        SceneManager.LoadScene(data.currentSceneName);
        Debug.Log("loaded:" + data.currentSceneName);

        #endregion
    }

    public void ButtonClicked(int buttonID)
    {
        Debug.Log("called");
        if (buttonID == 0)
        {
            Load(_filePath1);
        }
        else
        {
            Load(_filePath2);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _filePath1 = Path.Combine(Application.persistentDataPath, "save1.json");
        _filePath2 = Path.Combine(Application.persistentDataPath, "save2.json");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
