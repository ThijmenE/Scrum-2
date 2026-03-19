using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinSceneTimer : MonoBehaviour
{
    Timer DurationOfRun;
    TextMeshProUGUI FinishTime;
    void Start()
    {
        FinishTime = GameObject.Find("FinishTime").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        int minutes = Mathf.FloorToInt(DurationOfRun.timeElapsed / 60F);
        int seconds = Mathf.FloorToInt(DurationOfRun.timeElapsed - minutes * 60);
        FinishTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
