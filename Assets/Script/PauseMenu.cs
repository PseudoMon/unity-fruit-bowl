using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private VisualElement pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable() {
        UIDocument uiDocument = GetComponent<UIDocument>();
        VisualElement root = uiDocument.rootVisualElement;
        pauseMenu = root.Q("PauseMenu");
        pauseMenu.AddToClassList("undisplayed");

        Button pauseButton = root.Q("PauseButton") as Button;

        pauseButton.RegisterCallback<ClickEvent>((ClickEvent ev) =>
        {
            if (Time.timeScale != 0) StartPause();
            else EndPause();
        });

        root.Q("ContinueButton").RegisterCallback<ClickEvent>((ClickEvent ev) => EndPause());
        root.Q("ResetButton").RegisterCallback<ClickEvent>((ClickEvent ev) => ResetScene());
    }

    void StartPause() {
        Time.timeScale = 0;
        pauseMenu.RemoveFromClassList("undisplayed");
    }

    void EndPause() {
        Time.timeScale = 1;
        pauseMenu.AddToClassList("undisplayed");
    }

    void ResetScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
