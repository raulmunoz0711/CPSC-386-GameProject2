using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TextLogic : MonoBehaviour
{
    public GameObject LevelCompleteUI;
    public string nextLevelScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //UI stays hidden to start level
        LevelCompleteUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Opens settings at any point during the game
        if (Keyboard.current.escapeKey.isPressed)
        {
            SceneManager.LoadScene("SettingScene");
        }
    }

    public void ShowLevelComplete()
    {
        LevelCompleteUI.SetActive(true);
    }
    public void nextLevel()
    {
        //Allows me to keep player prefab and type in name of scene on unity.
        SceneManager.LoadScene(nextLevelScene);
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void settingsScene()
    {
        SceneManager.LoadScene("SettingScene");
    }

    public void levelselection()
    {
        SceneManager.LoadScene("Level Selection");
    }
}
