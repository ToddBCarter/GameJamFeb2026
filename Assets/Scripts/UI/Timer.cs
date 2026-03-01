using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    private float elapsedTime = 0f;
    private bool isRunning = false;

    public void StartTimer()
    {
        elapsedTime = 0f;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    private void Update()
    {
        if (!isRunning) return;

        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int hundredths = Mathf.FloorToInt((elapsedTime * 100) % 100);
        if (timerText != null)
        {
            timerText.text = $"{minutes:00}:{seconds:00}.{hundredths:00}";
        }
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }

    public void Won()
    {
        if (timerText != null)
        {
            RectTransform rect = timerText.GetComponent<RectTransform>();

            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.anchorMax = new Vector2(0.5f, 0.5f);

            rect.anchoredPosition = Vector2.zero;
            timerText.fontSize = 100f;
        }
    }
}