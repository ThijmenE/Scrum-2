using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Calls
    TextMeshProUGUI timerText;

    // Variables
    public float timeElapsed = 0f;

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        timerText.text = timeElapsed.ToString("F2");
        int minutes = Mathf.FloorToInt(timeElapsed / 60F);
        int seconds = Mathf.FloorToInt(timeElapsed - minutes * 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}