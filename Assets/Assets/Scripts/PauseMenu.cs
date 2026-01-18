using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject settingsUI;

    private bool isPaused = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsUI.activeSelf)
                CloseSettings();
            else
                TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        pauseMenuUI.SetActive(isPaused);
        settingsUI.SetActive(false);

        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void Resume()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false);
        settingsUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenSettings()
    {
        pauseMenuUI.SetActive(false);
        settingsUI.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
    public void GoToOpeningScene()
    {
        Resume();
        SceneManager.LoadScene("OpeningScene");
    }
}