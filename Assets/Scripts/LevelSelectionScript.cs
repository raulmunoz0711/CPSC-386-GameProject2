using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelSelectionScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    }
    public void level2()
    {
        SceneManager.LoadScene("Game2");
    }
    public void level3()
    {
        SceneManager.LoadScene("Game3");
    }
    public void returnMainmenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
