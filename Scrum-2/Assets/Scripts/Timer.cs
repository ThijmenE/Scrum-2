using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI timerText;
    TextMeshProUGUI FinishedTime;
    public float timeElapsed;

    void Start()
    {
        timerText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        FinishedTime = GameObject.Find("FinishTime").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Menu" && SceneManager.GetActiveScene().name != "Win Scene")
        {
            timeElapsed += Time.deltaTime;
            timerText.enabled = true;
            FinishedTime.enabled = false;
        }
        else if (SceneManager.GetActiveScene().name == "Menu")
        {
            timerText.enabled = false;
            FinishedTime.enabled = false;
            timeElapsed = 0;
        }
        else if (SceneManager.GetActiveScene().name == "Win Scene")
        {
            timerText.enabled = false;
            FinishedTime.enabled = true;
        }

        int minutes = Mathf.FloorToInt(timeElapsed / 60F);
        int seconds = Mathf.FloorToInt(timeElapsed - minutes * 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        FinishedTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}