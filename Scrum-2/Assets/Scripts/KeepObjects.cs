using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class KeepObjects : MonoBehaviour
{
    private static KeepObjects keepThisObject;
    public bool canvas = false;
    Canvas winSceneTime;
    private void Awake()
    {
        keepThisObject = this;
        DontDestroyOnLoad(gameObject);
        winSceneTime = GameObject.Find("WinScene Time").GetComponent<Canvas>();
    }

    private void Update()
    {
        if ((SceneManager.GetActiveScene().name == "Win Scene") && (canvas == true))
        {
            winSceneTime.enabled = true;
        }
        else if ((SceneManager.GetActiveScene().name != "Win Scene") && (canvas == true))
        {
            winSceneTime.enabled = false;
        }
    }
}
