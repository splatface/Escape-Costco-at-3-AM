using UnityEngine;
using UnityEngine.SceneManagement;

public class WinButton : MonoBehaviour
{
    public void ReturnHome()
    {
        SceneManager.LoadScene("OpeningScene");
    }
}
