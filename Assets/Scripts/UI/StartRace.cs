using TMPro;
using UnityEngine;

public class StartRace : MonoBehaviour
{
    [SerializeField] private GameObject startCanvas;
    [SerializeField] private TMP_Text countdownText;
    private float countdown = 3.3f;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    private void Update()
    {
        countdown -= Time.unscaledDeltaTime;
        countdownText.text = Mathf.Ceil(countdown).ToString();

        if (countdown <= 0f)
        {
            Debug.Log("countdown 0");
            Time.timeScale = 1f;
            startCanvas.SetActive(false);
        }
    }
}
