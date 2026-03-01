using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        SplitScreenCamera.isMulti = false;
    }

    public void StartGameSolo()
    {
        SplitScreenCamera.isMulti = false;
        SceneManager.LoadScene(1);
    }

    public void StartGameMulti()
    {
        SplitScreenCamera.isMulti = true;
        SceneManager.LoadScene(1);
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