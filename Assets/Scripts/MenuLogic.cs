using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //Gives each button a new scene to attach to
    public void startGame()
    {
        //Takes user to GameScene
        SceneManager.LoadScene("Level Selection");
        Debug.Log("Player loaded Level Selection Scene");
    }

    public void exitGame()
    {
        //Allows user to quit game
        Application.Quit();
        Debug.Log("User Quit Game");
    }

    public void gameSettings()
    {
        //Takes user to SettingsScene
        SceneManager.LoadScene("SettingScene");
        Debug.Log("Player loaded Settings Scene");
    }
}
