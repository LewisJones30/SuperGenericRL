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
    public bool isDead = false;
    bool turnSwapDelay = false;
    bool enemyDead = false;

    public loadNewRoom loadRoom;

    [SerializeField]
    Sprite[] Sprites = new Sprite[3]; //Slot 1 is default player, Slot 2 is player in mud, Slot 3 is dead player.
    void Start()
    {
        UIController = UI.GetComponent<UIController>();
        gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        //Check if game is paused, if paused, do not allow movement
        if (UIController.getPaused())
        {
            return;
        }
        if (enemyDead == true && !getTurn())
        {
            setTurn(true);
        }
        if (Turn && movedCount < 2 && isDead == false && turnSwapDelay == false) //Check if it is their turn, they aren't dead and the delay between enemy movement isn't active.
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                movedCount = 2;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (stuckInMud)//Absorb a turn to "get out" of the mud.
                {
                    movedCount += 1;
                    setStuckInMud(false);
                }
                if (hit = Physics2D.Raycast(transform.position + Vector3.up, Vector2.up, 0.1f))
                {
                    if (hit.collider.gameObject.tag == "BlockTerrain")
                    {
                        return;
                    }
                    if (hit.collider.gameObject.tag == "Door")
                    {
                        if (getKeyObtained() && enemyDead)
                        {
                            //Next room
                            UIController.addTurnsRemaining();
                            UIController.addRoomsCompleted(1);
                            Debug.Log("here 1");
                            loadRoom.loadNextTile(UIController.getRoomCompletedCount());
                            UIController.DisableKeySprite();
                        }
                        else
                        {
                            if (!enemyDead)
                            {
                                UIController.EnableUIKeyText(0);
                            }
                            else
                            {

                            }
                            UIController.EnableUIKeyText(1);

                            return;
                        }
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
                if (hit = Physics2D.Raycast(transform.position + Vector3.left, Vector2.left, 0.1f))
                {
                    Debug.DrawLine(transform.position, transform.position + (1 / 2 * Vector3.left), Color.white);
                    if (hit.collider.gameObject.tag == "BlockTerrain")
                    {
                        return;
                    }
                    if (hit.collider.gameObject.tag == "Door")
                    {
                        if (getKeyObtained() && enemyDead)
                        {
                            //Next room
                            UIController.addTurnsRemaining();
                            UIController.addRoomsCompleted(1);
                            Debug.Log("here 1");
                            loadRoom.loadNextTile(UIController.getRoomCompletedCount());
                            UIController.DisableKeySprite();
                        }
                        else
                        {
                            if (!enemyDead)
                            {
                                UIController.EnableUIKeyText(0);
                            }
                            else
                            {

                            }
                            UIController.EnableUIKeyText(1);

                            return;
                        }
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
                if (hit = Physics2D.Raycast(transform.position + Vector3.down, Vector2.down, 0.1f))
                {
                    if (hit.collider.gameObject.tag == "BlockTerrain")
                    {
                        return;
                    }
                    if (hit.collider.gameObject.tag == "Door")
                    {
                        if (getKeyObtained() && enemyDead)
                        {
                            //Next room
                            UIController.addTurnsRemaining();
                            UIController.addRoomsCompleted(1);
                            Debug.Log("here 1");
                            loadRoom.loadNextTile(UIController.getRoomCompletedCount());
                            UIController.DisableKeySprite();
                        }
                        else
                        {
                            if (!enemyDead)
                            {
                                UIController.EnableUIKeyText(0);
                            }
                            else
                            {

                            }
                            UIController.EnableUIKeyText(1);

                            return;
                        }
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
                if (hit = Physics2D.Raycast(transform.position + Vector3.right, Vector2.right, 0.1f))
                {
                    if (hit.collider.gameObject.tag == "BlockTerrain")
                    {
                        return;
                    }
                    if (hit.collider.gameObject.tag == "Door")
                    {
                        if (getKeyObtained() && enemyDead)
                        {
                            //Next room
                            UIController.addTurnsRemaining();
                            UIController.addRoomsCompleted(1);
                            Debug.Log("here 1");
                            loadRoom.loadNextTile(UIController.getRoomCompletedCount());
                            UIController.DisableKeySprite();
                        }
                        else
                        {
                            if (!enemyDead)
                            {
                                UIController.EnableUIKeyText(0);
                            }
                            else
                            {

                            }
                            UIController.EnableUIKeyText(1);
                            
                            return;
                        }
                    }
                }
                transform.position += Vector3.right;
                movedCount += 1;
                UIController.subTurnsRemaining(1);
                UIController.DisableUIKeyText();
            }
            if (movedCount == 1)
            {
                //gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[1];
            }
            if (movedCount == 2)
            {

                //gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[0];
                if (enemyDead)
                {
                    movedCount = 0;
                    return;
                }
                turnSwapDelay = true;
                StartCoroutine(setTurnDelayed(0.15f));
                
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
        gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[2];

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
        movedCount = 3;
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

    public void setEnemyDead(bool value)
    {
        enemyDead = value;
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
    public int getMoveCount()
    {
        return movedCount;
    }
    
    //Public calls

    public void PlayerKilled() //Called by enemy when the enemy "defeats" the player.
    {
        PlayerDead();
    }
    public void delaySetTurn()
    {
        StartCoroutine(setTurnDelayed());
    }
    IEnumerator setTurnDelayed()
    {
        yield return new WaitForSeconds(0.05f);
        setTurn(true);
        turnSwapDelay = false;
        movedCount = 0;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead == true)
        {
            return;
        }
        if (!getTurn())
        {
            return;
        }
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "EnemyRandom" || collision.gameObject.tag == "EnemyLocator")
        {
            if (collision.gameObject.tag == "EnemyRandom")
            {
                collision.gameObject.GetComponent<EnemyRandomMovement>().killedState();
            }
            else
            {
                collision.gameObject.GetComponent<EnemyTowardsPlayer>().killedState();
            }
            setEnemyDead(true);
        }
        if (collision.gameObject.tag == "Mud")
        {
            setStuckInMud(true);
        }
    }
}
