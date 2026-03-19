using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    private Label _timeLabel;
    private Button _menuButton;
    private Button _exitButton;

    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        _menuButton = root.Q<Button>("MenuButton");
        _exitButton = root.Q<Button>("ExitButton");


        _menuButton.clicked += MenuButtonClicked;
        _exitButton.clicked += ExitButtonClicked;
    }


    private void MenuButtonClicked() => SceneManager.LoadScene("Menu");
    private void ExitButtonClicked() => Application.Quit();
}
