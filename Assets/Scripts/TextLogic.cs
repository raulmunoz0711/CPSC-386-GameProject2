using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TextLogic : MonoBehaviour
{
    public GameObject LevelCompleteUI;
    public GameObject GamePausedUI;
    private bool GameisPaused = false;

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
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            TogglePause();
            Debug.Log("Player Loaded Pause Menu");
        }
    }

    public void ShowLevelComplete()
    {
        LevelCompleteUI.SetActive(true);
    }
    public void nextLevel()
    {
        /// Implemented with AI ///
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Game1")
            PlayerPrefs.SetInt("Level1Complete", 1);
        else if (currentScene == "Game2")
            PlayerPrefs.SetInt("Level2Complete", 1);

        PlayerPrefs.Save();
        Debug.Log(currentScene + " markes as complete.");

        if (!string.IsNullOrEmpty(nextLevelScene))
        {
            SceneManager.LoadScene(nextLevelScene);
            Debug.Log("Player loaded next level");
        }
        /// Implemented with AI ///
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Player returned to Main Menu");
    }

    public void settingsScene()
    {
        SceneManager.LoadScene("SettingScene");
        Debug.Log("Player loaded Settings Scene");
    }

    public void levelselection()
    {
        SceneManager.LoadScene("Level Selection");
        Debug.Log("Player loaded Level Selection Scene");
    }

    public void exitGame()
    {
        Application.Quit();
        Debug.Log("User Quit Game");
    }

    void TogglePause()
    {
        GameisPaused = !GameisPaused;
        GamePausedUI.SetActive(GameisPaused);
        if (GameisPaused)
        {
            //Paused Game
            Time.timeScale = 0f;
        }
        else
        {
            //Resumes Game
            Time.timeScale = 1f;
        }
    }

    public void resumeGame()
    {
        GameisPaused = false;
        GamePausedUI.SetActive(false);
        Time.timeScale = 1f;
    }
}