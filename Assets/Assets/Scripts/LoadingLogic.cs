using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadingLogic : MonoBehaviour
{

    string filePath1 = Path.Combine(Application.persistentDataPath, "save1.json");
    string filePath2 = Path.Combine(Application.persistentDataPath, "save2.json");

    void Load(string filePath)
    {
        File.ReadAllLines(filePath);

        SavingManager data = JsonUtility.FromJson<SavingManager>(filePath);

        #region Loading Data Logic

        // player stuff; need Instance to get
        FullInventory.Instance.SetAllItems(data.allPossessedItems);
        BarInventory.Instance.SetEquippedItems(data.allEquippedItems);
        SceneManager.LoadScene(data.currentSceneName);

        #endregion
    }

    public void ButtonClicked(int buttonID)
    {
        if (buttonID == 0)
        {
            Load(filePath1);
        }
        else
        {
            Load(filePath2);
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
