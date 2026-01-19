using UnityEngine;
using UnityEngine.SceneManagement;

public class RedRoomDoor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string[] inv = BarInventory.Instance.GetCurrentItems();
        if (collision.gameObject.CompareTag("Player") && inv[2] == "RedKeyCard")
        {
            SceneManager.LoadScene("FinalRoom");
        }
    }
}
