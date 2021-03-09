using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    void Start()
    {
        TurnsRemainingText = TurnsRemainingUI.GetComponent<Text>();
        RoomsCompletedText = RoomsCompletedCountUI.GetComponent<Text>();
        KeyImage = KeySprite.GetComponent<Image>();
        KeySprite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Paused)
        {
            UpdateUI();
            //Debugging
        }
        else
        {

        }
    }
    void UpdateUI()
    {
        if (TurnsRemainingText != null) //Only one check required - both UI elements will be on the same UI page.
        {
            TurnsRemainingText.text = "Turns Remaining: " + getTurnsRemaining();
            RoomsCompletedText.text = "Rooms Completed: " + getRoomCompletedCount();
        }


    }

    public void EnableKeySprite() //Called by key when player collides with key
    {
        KeySprite.SetActive(true);
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
    public void addTurnsRemaining(int value)
    {
        TurnsRemaining += value;
    }
    public void subTurnsRemaining(int value)
    {
        TurnsRemaining -= value;
    }

}
