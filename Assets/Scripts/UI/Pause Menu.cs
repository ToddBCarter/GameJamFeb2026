using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseMenu2;

    private bool isPaused = false;

    void Start()
    {
        pauseMenu.SetActive(false);
        pauseMenu2.SetActive(false);
    }

    void Update()
    {
        Debug.Log(1f / Time.deltaTime);

        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            if (isPaused)
            {
                ResumeGame(1);
            }
            else
            {
                PauseGame(1);
            }
        }
        else if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            if (isPaused)
            {
                ResumeGame(2);
            }
            else
            {
                PauseGame(2);
            }
        }
    }

    public void ResumeGame(int i)
    {
        if(SplitScreenCamera.isMulti && i == 1)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
        else if(SplitScreenCamera.isMulti && i == 2)
        {
            pauseMenu2.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
    }

    public void PauseGame(int i)
    {
        if (SplitScreenCamera.isMulti && i == 1)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
        else if (SplitScreenCamera.isMulti && i == 2)
        {
            pauseMenu2.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
