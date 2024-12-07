using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    void Update()
    {

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

        if (Input.GetKeyDown(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.F4))
        {
            QuitGame();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;

        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;

        if (pauseMenuUI != null) 
        {
            pauseMenuUI.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit(); 
        Debug.Log("Game Quit"); 
    }
    public void RestartGame()
    {
        Time.timeScale = 1f; 
        isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
