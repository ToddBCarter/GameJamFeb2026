using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseMenu2;

    private bool isPaused = false;
    private InputAction pauseAction;
    private InputAction pauseAction2;

    void Awake()
    {
        pauseMenu.SetActive(false);
        pauseMenu2.SetActive(false);

        pauseAction = InputSystem.actions.FindAction("Pause");
        pauseAction2 = InputSystem.actions.FindAction("Pause2");
    }

    void Update()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame || pauseAction.triggered)
        {
            Debug.Log("Got it pressed");
            if (isPaused)
            {
                ResumeGame(1);
            }
            else
            {
                PauseGame(1);
            }
        }
        else if (Keyboard.current.pKey.wasPressedThisFrame || pauseAction2.triggered)
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
        if (SplitScreenCamera.isMulti && i == 2)
        {
            pauseMenu2.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
        /*if (SplitScreenCamera.isMulti && i == 1)
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
        }*/
    }

    public void PauseGame(int i)
    {
        if (SplitScreenCamera.isMulti && i == 2)
        {
            pauseMenu2.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
        /*if (SplitScreenCamera.isMulti && i == 1)
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
        }*/
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
