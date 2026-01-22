using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenCardScene : MonoBehaviour
{
    public GameObject CardButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string[] inv = FullInventory.Instance.GetAllItems();
        if (inv.Contains("Vinegar"))
        {
            CardButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CardScene()
    {
        SceneManager.LoadScene("CardGame");
    }
}
