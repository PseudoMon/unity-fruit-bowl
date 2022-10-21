using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScreenUI : MonoBehaviour
{
    private Button _button;
    private Toggle _toggle;

    private int _clickCount;
    
    private void OnEnable()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        VisualElement root = uiDocument.rootVisualElement;

        _button = root.Q("button") as Button;
        _toggle = root.Q("toggle") as Toggle;

        _button.RegisterCallback<ClickEvent>(PrintClickMessage);

        TextField _inputField = root.Q("input-message") as TextField;
        _inputField.RegisterCallback<ChangeEvent<string>>(InputMessage);

    }

    private void PrintClickMessage(ClickEvent evt)
    {
        _clickCount += 1;

        Debug.Log($"Button was clicked!" + (_toggle.value ? $" Count: {_clickCount}" : ""));
    }

    private void InputMessage(ChangeEvent<string> evt)
    {
        Debug.Log($"{evt.newValue} -> {evt.target}");
    }
}
