using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    bool Turn = true;
    int movedCount = 0;
    bool KeyObtained = false;
    // Start is called before the first frame update



    // Update is called once per frame
    void Update()
    {
        //Check if game is paused, if paused, do not allow movement

        if (Turn) //Check if it is the player's turn to move.
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.position += Vector3.up;
                movedCount += 1;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position += Vector3.left;
                movedCount += 1;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {

                transform.position += Vector3.down;
                movedCount += 1;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position += Vector3.right;
                movedCount += 1;
            }
            if (movedCount == 2)
            {
                setTurn(false);
            }
        }
    }

    public void setTurn(bool value)
    {
        if (value)
        {
            movedCount = 0;
        }
        Turn = value;
    }

    public void setKeyObtained(bool value)
    {
        KeyObtained = value;
    }

    public bool getTurn()
    {
        return Turn;
    }
    
    public bool getKeyObtained()
    {
        return KeyObtained;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (movedCount > 0)
        {
            Destroy(collision.gameObject);
        }
    }
}
