using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int AIs = 2;
    private void Awake()
    {
        SplitScreenCamera.isMulti = false;
    }

    public void StartGameSolo()
    {
        SplitScreenCamera.isMulti = false;
        FinishLine.totalRacers = AIs + 1;
        SceneManager.LoadScene(1);
    }

    public void StartGameMulti()
    {
        FinishLine.totalRacers = AIs + 2;
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