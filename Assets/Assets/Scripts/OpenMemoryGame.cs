using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMemoryGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Prevent scene change if game is paused
        if (Time.timeScale == 0f) return;

        // Only the player can trigger it
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("MemoryGame");
        }
    }
}
