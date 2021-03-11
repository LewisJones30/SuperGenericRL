using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update


    const int TURNS_GRANTED_ROOM_COMPLETION = 25;
    int RoomCompletedCount = 0;
    int TurnsRemaining = 25;
    bool Paused = false;


    [SerializeField]
    GameObject TurnsRemainingUI;
    Text TurnsRemainingText;
    [SerializeField]
    GameObject RoomsCompletedCountUI;
    Text RoomsCompletedText;
    [SerializeField]
    GameObject KeySprite;
    Image KeyImage;
    [SerializeField]
    GameObject IngameCanvasObj;
    [SerializeField]
    GameObject PausedCanvasObj;
    [SerializeField]
    GameObject KeyNotUnlocked;
    Text KeyUnlockText;
    [SerializeField]
    GameObject GameOverCanvas;
    [SerializeField]
    GameObject GameOverRoomsCompletedText;
    void Start()
    {
        TurnsRemainingText = TurnsRemainingUI.GetComponent<Text>();
        RoomsCompletedText = RoomsCompletedCountUI.GetComponent<Text>();
        KeyImage = KeySprite.GetComponent<Image>();
        KeySprite.SetActive(false);
        PausedCanvasObj.SetActive(false);
        KeyNotUnlocked.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Paused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Paused = true;
                ShowPausedUI();
                return; //Ensure updateUI doesn't run as this will cause crash.
            }
            UpdateUI();
            //Debugging
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Paused = false;
                ShowInGameUI();
            }
        }
    }


    //==========================================================UI control methods
    void UpdateUI()
    {
        if (TurnsRemainingText != null) //Only one check required - both UI elements will be on the same UI page.
        {
            TurnsRemainingText.text = "Turns Remaining: " + getTurnsRemaining();
            RoomsCompletedText.text = "Rooms Completed: " + getRoomCompletedCount();
        }


    }

    void ShowPausedUI()
    {
        IngameCanvasObj.SetActive(false);
        PausedCanvasObj.SetActive(true);
        ShowUIElements("HowToPlayPause", "MainPause");
    }
    void ShowInGameUI()
    {
        IngameCanvasObj.SetActive(true);
        PausedCanvasObj.SetActive(false);
    }


    //Button callers
    public void ResumeGame() //Callable by buttons
    {
        if (IngameCanvasObj.activeSelf)
        {
            return;
        }
        else
        {
            ShowInGameUI();
            Paused = false;
        }
    }
    public void ShowUIElements(string hideTag, string showTag) //Used with the in-game pause menu
    {
        foreach (GameObject obj in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (obj.tag == hideTag)
            {
                obj.SetActive(false);
            }
            if (obj.tag == showTag)
            {
                obj.SetActive(true);
            }
        }
    }

    //Public methods

    public void EnableUIKeyText()
    {
        KeyNotUnlocked.SetActive(true);
    }
    public void DisableUIKeyText()
    {
        if (KeyNotUnlocked.activeSelf)
        {
            KeyNotUnlocked.SetActive(false);
        }    
    }
    public void EnableKeySprite() //Called by key when player collides with key
    {
        KeySprite.SetActive(true);
    }
    public void DisableKeySprite()
    {
        KeySprite.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().setKeyObtained(false);
    }
    public void EnableGameOverCanvas()
    {
        IngameCanvasObj.SetActive(false);
        GameOverCanvas.SetActive(true);
        if (getRoomCompletedCount() == 0)
        {
            GameOverRoomsCompletedText.GetComponent<Text>().text = "No rooms completed. Better luck next time!";
            GameOverRoomsCompletedText.GetComponent<Text>().fontSize = 75;
        }
        else
        {
            GameOverRoomsCompletedText.GetComponent<Text>().text = "You completed" + getRoomCompletedCount() + " rooms!";
        }
    }
    //Public getters
    public int getRoomCompletedCount()
    {
        return RoomCompletedCount;
    }
    public int getTurnsRemaining()
    {
        return TurnsRemaining;
    }
    public bool getPaused()
    {
        return Paused;
    }


    //Public setters
    public void addRoomsCompleted(int value)
    {
        RoomCompletedCount += value;
    }
    public void addTurnsRemaining() //Used to add the constant turns_granted_room_completion
    {
        TurnsRemaining += TURNS_GRANTED_ROOM_COMPLETION;
    }
    public void addTurnsRemaining(int value) //Overload - pass in a value instead if needed as an additional feature.
    {
        TurnsRemaining += value;
    }
    public void subTurnsRemaining(int value) //Subtract value from turns remaining. Usually 1. Mud can do 2.
    {
        TurnsRemaining -= value;
    }

}
