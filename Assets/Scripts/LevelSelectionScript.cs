using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionScript : MonoBehaviour
{
    /// Implemented with AI ///
    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    /// Implemented with AI ///

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /// Implemented with AI ///
         // Level 1 is always unlocked
        if (level1Button != null)
            level1Button.interactable = true;

        // Lock Level 2 if Level1 not completed
        if (level2Button != null)
            level2Button.interactable = PlayerPrefs.GetInt("Level1Complete", 0) == 1;

        // Lock Level 3 if Level2 not completed
        if (level3Button != null)
            level3Button.interactable = PlayerPrefs.GetInt("Level2Complete", 0) == 1;
        /// Implemented with AI ///
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.isPressed)
        {
            SceneManager.LoadScene("SettingScene");
        }
    }

    public void level1()
    {
        SceneManager.LoadScene("Game1");
        Debug.Log("Player loaded game1");
    }
    public void level2()
    {
        /// Implemented with AI ///
        if (PlayerPrefs.GetInt("Level1Complete", 0) == 1)
        /// Implemented with AI ///
        {
            SceneManager.LoadScene("Game2");
            Debug.Log("Player loaded game2");
        }
        else
        {
            Debug.Log("Level 2 is locked.");
        }
        
    }
    public void level3()
    {
        /// Implemented with AI ///
        if (PlayerPrefs.GetInt("Level2Complete", 0) == 1)
        /// Implemented with AI ///
        {
            SceneManager.LoadScene("Game3");
            Debug.Log("Player loaded game3");
        }
        else
        {
            Debug.Log("Level 3 is locked.");
        }
        
    }
    public void returnMainmenu()
    {
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Player loaded Main Menu");
    }
}
