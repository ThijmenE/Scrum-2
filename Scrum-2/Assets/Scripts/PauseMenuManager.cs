using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private VisualTreeAsset _ContinueButtonTemplate;

    private VisualElement _buttonsWrapper;
    private Button _PauseButton;
    private Button _ContinueButton;

    private VisualElement _PauseMenuPanel;
    private List<Button> _PauseMenuPanelButtons = new List<Button>();

    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        _buttonsWrapper = root.Q<VisualElement>("Buttons");
        _PauseButton = root.Q<Button>("PauseButton");

        _PauseButton.clicked += PauseButtonClicked;

        _PauseMenuPanel = _ContinueButtonTemplate.CloneTree().Q<VisualElement>("Wrapper");
        _PauseMenuPanel.style.display = DisplayStyle.None;
        _buttonsWrapper.Add(_PauseMenuPanel);

        _ContinueButton = _PauseMenuPanel.Q<Button>("ContinueButton");
        AddPanelButton(_PauseMenuPanel, _PauseMenuPanelButtons, "ContinueButton", ContinueButtonClicked);
        AddPanelButton(_PauseMenuPanel, _PauseMenuPanelButtons, "MenuButton", MenuButtonClicked);
    }

        private void Start()
    {
        Time.timeScale = 1f;
    }

    private void AddPanelButton(VisualElement panel, List<Button> list, string name, System.Action callback)
    {
        var button = panel.Q<Button>(name);
        if (button != null)
        {
            button.clicked += callback;
            button.style.display = DisplayStyle.None;
            list.Add(button);
        }
        else
        {
            Debug.LogWarning($"Button '{name}' not found in template.");
        }
    }

    private void ShowPanel(VisualElement panel, List<Button> buttons)
    {
        _PauseButton.style.display = DisplayStyle.None;
        _ContinueButton.style.display = DisplayStyle.None;

        panel.style.display = DisplayStyle.Flex;

        foreach (var b in buttons)
            b.style.display = DisplayStyle.Flex;
    }

    private void HidePanel(VisualElement panel, List<Button> buttons)
    {
        panel.style.display = DisplayStyle.None;

        foreach (var b in buttons)
            b.style.display = DisplayStyle.None;

        _PauseButton.style.display = DisplayStyle.Flex;
        _ContinueButton.style.display = DisplayStyle.Flex;
    }

    private void PauseButtonClicked()
    {
        ShowPanel(_PauseMenuPanel, _PauseMenuPanelButtons);
        Time.timeScale = 0;
    }

    private void ContinueButtonClicked()
    {
        HidePanel(_PauseMenuPanel, _PauseMenuPanelButtons);
        Time.timeScale = 1;
    }

    private void MenuButtonClicked() => SceneManager.LoadScene("Menu");
}