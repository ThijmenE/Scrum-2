using UnityEngine;
using UnityEngine.SceneManagement;

public class Winningscene : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            WinScene();
        }
    }

    private void WinScene()
    {
        SceneManager.LoadScene("Win Scene");
    }
}
