using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{


    bool Turn = true;
    int movedCount = 0;
    bool KeyObtained = false;
    bool stuckInMud = false;
    // Start is called before the first frame update
    [SerializeField]
    GameObject UI;
    UIController UIController;
    RaycastHit2D hit;
    bool isDead = false;
    bool turnSwapDelay = false;
    void Start()
    {
        UIController = UI.GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if game is paused, if paused, do not allow movement
        if (UIController.getPaused())
        {
            return;
        }
        if (Turn && movedCount < 2 && isDead == false && turnSwapDelay == false) //Check if it is their turn, they aren't dead and the delay between enemy movement isn't active.
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (stuckInMud)//Absorb a turn to "get out" of the mud.
                {
                    movedCount += 1;
                    setStuckInMud(false);
                }
                if (hit = Physics2D.Raycast(transform.position + Vector3.up, Vector2.up, 0.5f))
                {
                    if (hit.collider.gameObject.tag == "BlockTerrain")
                    {
                        return;
                    }
                    if (getKeyObtained())
                    {
                        //Next room
                        UIController.addTurnsRemaining();
                        UIController.addRoomsCompleted(1);
                        UIController.DisableUIKeyText();
                    }
                    else
                    {
                        UIController.EnableUIKeyText();
                    }
                }
                transform.position += Vector3.up;
                movedCount += 1;
                UIController.subTurnsRemaining(1);
                UIController.DisableUIKeyText();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (stuckInMud)//Absorb a turn to "get out" of the mud.
                {
                    movedCount += 1;
                    setStuckInMud(false);
                }
                if (hit = Physics2D.Raycast(transform.position + Vector3.left, Vector2.left, 0.5f))
                {
                    Debug.DrawLine(transform.position, transform.position + (1 / 2 * Vector3.left), Color.white);
                    if (hit.collider.gameObject.tag == "BlockTerrain")
                    {
                        return;
                    }
                    if (getKeyObtained())
                    {
                        //Next room
                        UIController.addTurnsRemaining();
                        UIController.addRoomsCompleted(1);
                    }
                    else
                    {
                        UIController.EnableUIKeyText();
                    }
                }
                transform.position += Vector3.left;
                movedCount += 1;
                UIController.subTurnsRemaining(1);
                UIController.DisableUIKeyText();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (stuckInMud)//Absorb a turn to "get out" of the mud.
                {
                    movedCount += 1;
                    setStuckInMud(false);
                }
                if (hit = Physics2D.Raycast(transform.position + Vector3.down, Vector2.down, 0.5f))
                {
                    if (hit.collider.gameObject.tag == "BlockTerrain")
                    {
                        return;
                    }
                    if (getKeyObtained())
                    {
                        //Next room
                        UIController.addTurnsRemaining();
                        UIController.addRoomsCompleted(1);
                    }
                    else
                    {
                        UIController.EnableUIKeyText();
                    }
                }
                transform.position += Vector3.down;
                movedCount += 1;
                UIController.subTurnsRemaining(1);
                UIController.DisableUIKeyText();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (stuckInMud)//Absorb a turn to "get out" of the mud.
                {
                    movedCount += 1;
                    setStuckInMud(false);
                }
                if (hit = Physics2D.Raycast(transform.position + Vector3.right, Vector2.right, 0.5f))
                {
                    if (hit.collider.gameObject.tag == "BlockTerrain")
                    {
                        return;
                    }
                    if (hit.collider.gameObject.tag == "Door")
                    {
                        if (getKeyObtained())
                        {
                            //Next room
                            UIController.addTurnsRemaining();
                            UIController.addRoomsCompleted(1);
                        }
                        else
                        {
                            UIController.EnableUIKeyText();
                        }
                    }
                }
                transform.position += Vector3.right;
                movedCount += 1;
                UIController.subTurnsRemaining(1);
                UIController.DisableUIKeyText();
            }
            if (movedCount == 2)
            {
                turnSwapDelay = true;
                StartCoroutine(setTurnDelayed(0.5f));
                movedCount = 0;
            }
            if (UIController.getTurnsRemaining() == 0)
            {
                PlayerDead();
            }
        }
    }


    void PlayerDead()
    {
        //code when player dies.

        //Play death animation.
        GameObject.Find("GameOverText").GetComponent<Text>().enabled = true;
        isDead = true;
        StartCoroutine("PlayerDeadAnims");
    }
    IEnumerator PlayerDeadAnims()
    {
        GameObject i = GameObject.Find("GameOverText");
        i.GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(5f);
        i.GetComponent<Text>().enabled = false;
        UIController.EnableGameOverCanvas();
    }

    //Private sets
    IEnumerator setTurnDelayed(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        setTurn(false);
        turnSwapDelay = false;
    }
    void setStuckInMud(bool value)
    {
        stuckInMud = value;
    }

    //Public sets
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

    //Public gets
    public bool getTurn()
    {
        return Turn;
    }
    public bool getStuckInMud()
    {
        return stuckInMud;
    }
    public bool getKeyObtained()
    {
        return KeyObtained;
    }
    
    //Public calls

    public void PlayerKilled() //Called by enemy when the enemy "defeats" the player.
    {
        PlayerDead();
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (movedCount > 0 && collision.gameObject.tag == "EnemyRandom" || collision.gameObject.tag == "EnemyLocator")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Mud")
        {
            setStuckInMud(true);
        }
    }
}
