using UnityEngine;
using UnityEngine.SceneManagement;

public class YellowRoomDoor : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("collided");
            Debug.Log(inv[1]);
        }
        if (collision.gameObject.CompareTag("Player") && inv[1] == "YellowKeyCard")
        {
            SceneManager.LoadScene("ManagerRoom");
        }
    }
}
