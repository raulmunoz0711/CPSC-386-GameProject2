using UnityEngine;
using UnityEngine.SceneManagement;

public class TextLogic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextLevel()
    {
        SceneManager.LoadScene("Game2");
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void settingsScne()
    {
        SceneManager.LoadScene("SettingScene");
    }
}
