using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCaller : MonoBehaviour
{
    // All methods in this class are public to allow button accessibility!
    [SerializeField]
    UIController UI;
    public void QuitGame() //Quit the game immediately. Coded for both unity editor and in-game.
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else  
        Application.Quit();
#endif
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("map gen"); //Default scene for the game currently. Ensure that this is changed.
    }
    public void ContinueGame()
    {
        if (UI != null)
        {
            UI.ResumeGame();
        }
        else
        {
            Debug.LogError("Error - UI is null in button call!");
        }
    }
    public void ShowHowToPlay()
    {
        UI.ShowUIElements("MainPause", "HowToPlayPause");
    }
    public void ShowMainPause()
    {
        UI.ShowUIElements("HowToPlayPause", "MainPause");
    }
}
