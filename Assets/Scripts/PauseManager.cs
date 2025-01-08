using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;
    private AudioManager audioManager;

    void Awake()
    {
        // Find the AudioManager in the scene
        GameObject audioManagerObject = GameObject.FindGameObjectWithTag("AudioManager");
        if (audioManagerObject != null)
        {
            audioManager = audioManagerObject.GetComponent<AudioManager>();
        }
        else
        {
            Debug.LogWarning("AudioManager not found! Sound effects will not play.");
        }

        // Ensure the pause menu is inactive at the start
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
        else
        {
            Debug.LogError("PauseMenuUI is not assigned in the Inspector!");
        }
    }

    void Update()
    {
        // Pause/Resume toggle
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        // Restart game with R key
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        // Quit game (Editor and build)
        if (Input.GetKeyDown(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.F4))
        {
            QuitGame();
        }
    }

    public void PauseGame()
    {
        Debug.Log("PauseGame() called");
        Time.timeScale = 0f;
        isPaused = true;

        if (audioManager != null)
        {
            audioManager.PlaySFX(audioManager.gameover); // Play the gameover sound effect
        }

        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
            Debug.Log("pauseMenuUI activated");
        }
        else
        {
            Debug.LogError("pauseMenuUI is not assigned! Ensure it is assigned in the Inspector.");
        }
    }

    public void ResumeGame()
    {
        Debug.Log("ResumeGame() called");
        Time.timeScale = 1f;
        isPaused = false;

        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
            Debug.Log("pauseMenuUI deactivated");
        }
        else
        {
            Debug.LogError("pauseMenuUI is not assigned! Ensure it is assigned in the Inspector.");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");

        if (audioManager != null)
        {
            audioManager.PlaySFX(audioManager.gameover); // Play the gameover sound effect
        }

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the editor
#else
        Application.Quit(); // Quit the application in build mode
#endif
    }

    public void RestartGame()
    {
        Debug.Log("Restarting game...");

        Time.timeScale = 1f; // Reset Time Scale
        isPaused = false;

        if (audioManager != null)
        {
            audioManager.PlaySFX(audioManager.gameover); // Play the gameover sound effect
        }

        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false); // Ensure the pause menu is hidden before restarting
        }

        // Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
