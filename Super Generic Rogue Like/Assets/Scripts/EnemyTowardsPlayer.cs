using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTowardsPlayer : MonoBehaviour
{

    GameObject player;
    PlayerMovement playerMove;
    RaycastHit2D hit;
    [SerializeField]
    Sprite[] sprites = new Sprite[2]; //Sprite 0 is default state, sprite 1 is dead.
    public bool dead = false;
    bool moved = false;
    const float RAYCAST_DISTANCE = 0.2f;
    [SerializeField]
    AudioClip step;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMove = player.GetComponent<PlayerMovement>();
        playerMove.setEnemyDead(false);
    }

    // Update is called once per frame
    void Update()
    {
        int Roll;
        if (playerMove.getTurn() && dead == false)
        {
            moved = false;
            playerMove.setEnemyDead(false); //As the enemy is still alive, reset the "enemy dead", incase another enemy triggers it.
        }
        if (player != null && !playerMove.getTurn() && dead == false && moved == false)
        {
            Roll = Random.Range(0, 2);
            Vector3 Gap = transform.position - player.transform.position;
            if (Gap.x != 0)
            {
                if (Gap.x < 0) //less than 0, as in the enemy is to the left of the player
                {
                    //determine if y is 0. If y is 0, then always move right X direction.
                    //if y is more than 0, 50/50 whether it moves right X direction or down Y direction.
                    //if y is less than 0, 50/50 whether it moves right X direction or up Y direction.
                    if (Gap.y == 0)
                    {
                        if (hit = Physics2D.Raycast(transform.position + Vector3.right, Vector2.right, RAYCAST_DISTANCE))
                        {
                            if (hit.collider.gameObject.tag == "BlockTerrain" || hit.collider.gameObject.tag == "EnemyRandom" || hit.collider.gameObject.tag == "EnemyLocator") //if the player is directly to the right, but behind terrain, check if up or down is free.
                            {
                                if (hit = Physics2D.Raycast(transform.position + Vector3.down, Vector2.down, RAYCAST_DISTANCE)) //Prefer going down, if down is blocked, go up.
                                {
                                    if (hit.collider.gameObject.tag == "BlockTerrain" || hit.collider.gameObject.tag == "EnemyRandom" || hit.collider.gameObject.tag == "EnemyLocator")
                                    {
                                        transform.position += Vector3.up;
                                        Debug.Log("16");
                                        playerMove.delaySetTurn();
                                        moved = true;
                                        playEnemyStep();
                                        return;
                                    }
                                }
                                transform.position += Vector3.down;
                                playerMove.delaySetTurn();
                                moved = true;
                                playEnemyStep();
                                return;

                            }
                        }
                        transform.position += Vector3.right;
                        Debug.Log(0);
                        playerMove.delaySetTurn();
                        moved = true;
                        playEnemyStep();
                        return;
                    }
                    if (Gap.y > 0)
                    {
                        if (Roll == 0)
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.right, Vector2.right, RAYCAST_DISTANCE)) //if the right is blocked, go down.
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain" || hit.collider.gameObject.tag == "EnemyRandom" || hit.collider.gameObject.tag == "EnemyLocator")
                                {
                                    transform.position += Vector3.down;
                                    Debug.Log("2");
                                    playerMove.delaySetTurn();
                                    moved = true;
                                    playEnemyStep();
                                    return;

                                }
                                  
                            }
                            transform.position += Vector3.right;
                            Debug.Log("1");
                            playerMove.delaySetTurn();
                            moved = true;
                            playEnemyStep();
                            return;
                        }
                        else
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.down, Vector2.down, RAYCAST_DISTANCE)) //If the down is blocked, go right.
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain" || hit.collider.gameObject.tag == "EnemyRandom" || hit.collider.gameObject.tag == "EnemyLocator")
                                {
                                    transform.position += Vector3.right;
                                    playerMove.delaySetTurn();
                                    moved = true;
                                    playEnemyStep();
                                    return;
                                }
                            }
                            transform.position += Vector3.down;
                            Debug.Log("2");
                            playerMove.delaySetTurn();
                            moved = true;
                            playEnemyStep();
                            return;
                        }
                    }
                    else
                    {
                        if (Roll == 0)
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.right, Vector2.right, RAYCAST_DISTANCE)) //If the right is blocked, go up.
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain" || hit.collider.gameObject.tag == "EnemyRandom" || hit.collider.gameObject.tag == "EnemyLocator")
                                {
                                    transform.position += Vector3.up;
                                    Debug.Log("15");
                                    playerMove.delaySetTurn();
                                    moved = true;
                                    playEnemyStep();
                                    return;
                                }
                            }
                            transform.position += Vector3.right;
                            Debug.Log("3");
                            playerMove.delaySetTurn();
                            moved = true;
                            playEnemyStep();
                            return;
                        }
                        else
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.up, Vector2.up, RAYCAST_DISTANCE)) //If the up is blocked, go right.
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain" || hit.collider.gameObject.tag == "EnemyRandom" || hit.collider.gameObject.tag == "EnemyLocator")
                                {
                                    transform.position += Vector3.right;
                                    playerMove.delaySetTurn();
                                    moved = true;
                                    playEnemyStep();
                                    return;
                                }
                            }
                            transform.position += Vector3.up;
                            Debug.Log("4");
                            playerMove.delaySetTurn();
                            moved = true;
                            playEnemyStep();
                            return;
                        }
                    }

                }
                else //x > 0
                {
                    if (Gap.y > 0)
                    {
                        if (Roll == 0)
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.left, Vector2.left, RAYCAST_DISTANCE)) //if left is blocked, go down.
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain" || hit.collider.gameObject.tag == "EnemyRandom" || hit.collider.gameObject.tag == "EnemyLocator")
                                {
                                    transform.position += Vector3.down;
                                    playerMove.delaySetTurn();
                                    moved = true;
                                    playEnemyStep();
                                    return;
                                }
                            }
                            transform.position += Vector3.left;
                            Debug.Log("6");
                            playerMove.delaySetTurn();
                            moved = true;
                            playEnemyStep();
                            return;
                        }
                        else
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.down, Vector2.down, RAYCAST_DISTANCE)) //if down is blocked, go left.
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain" || hit.collider.gameObject.tag == "EnemyRandom" || hit.collider.gameObject.tag == "EnemyLocator")
                                {
                                    transform.position += Vector3.left;
                                    playerMove.delaySetTurn();
                                    moved = true;
                                    playEnemyStep();
                                    return;
                                }
                            }
                            transform.position += Vector3.down;
                            Debug.Log("7");
                            playerMove.delaySetTurn();
                            moved = true;
                            playEnemyStep();
                            return;
                        }
                    }
                    else
                    {
                        if (Roll == 0)
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.left, Vector2.left, RAYCAST_DISTANCE)) //if left is blocked, go up.
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain" || hit.collider.gameObject.tag == "EnemyRandom" || hit.collider.gameObject.tag == "EnemyLocator")
                                {
                                    transform.position += Vector3.up;
                                    Debug.Log("14");
                                    playerMove.delaySetTurn();
                                    moved = true;
                                    playEnemyStep();
                                    return;
                                }
                            }
                            transform.position += Vector3.left;
                            Debug.Log("8");
                            playerMove.delaySetTurn();
                            moved = true;
                            playEnemyStep();
                            return;
                        }
                        else
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.up, Vector2.up, RAYCAST_DISTANCE)) //if up is blocked, go left.
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain" || hit.collider.gameObject.tag == "EnemyRandom" || hit.collider.gameObject.tag == "EnemyLocator")
                                {
                                    transform.position += Vector3.left;
                                    playerMove.delaySetTurn();
                                    moved = true;
                                    return;
                                }
                            }
                            transform.position += Vector3.up;
                            Debug.Log("9");
                            playerMove.delaySetTurn();
                            moved = true;
                            playEnemyStep();
                            return;
                        }
                    }
                }
            }
            else // x = 0;
            {
                //Determine if above or below, move towards.
                if (Gap.y > 0)
                {
                    if (hit = Physics2D.Raycast(transform.position + Vector3.down, Vector2.down, RAYCAST_DISTANCE)) //if down is blocked, check left
                    {
                        if (hit.collider.gameObject.tag == "BlockTerrain" || hit.collider.gameObject.tag == "EnemyRandom" || hit.collider.gameObject.tag == "EnemyLocator")
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.down, Vector2.down, RAYCAST_DISTANCE)) //if left is blocked, go right.
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain" || hit.collider.gameObject.tag == "EnemyRandom" || hit.collider.gameObject.tag == "EnemyLocator")
                                {
                                    transform.position += Vector3.right;
                                    playerMove.delaySetTurn();
                                    moved = true;
                                    playEnemyStep();
                                    return;
                                }
                            }
                            
                            {
                                transform.position += Vector3.left;
                                playerMove.delaySetTurn();
                                moved = true;
                                playEnemyStep();
                                return;
                            }
                        }
                    }
                    transform.position += Vector3.down;
                    Debug.Log("10");
                    playerMove.delaySetTurn();
                    moved = true;
                    playEnemyStep();
                    return;
                }
                else
                {
                    if (hit = Physics2D.Raycast(transform.position + Vector3.up, Vector2.up, RAYCAST_DISTANCE)) //if up is blocked, check left.
                    {
                        if (hit.collider.gameObject.tag == "BlockTerrain" || hit.collider.gameObject.tag == "EnemyRandom" || hit.collider.gameObject.tag == "EnemyLocator")
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.right, Vector2.right, RAYCAST_DISTANCE)) 
                            {
                                if  (hit.collider.gameObject.tag == "BlockTerrain" || hit.collider.gameObject.tag == "EnemyRandom" || hit.collider.gameObject.tag == "EnemyLocator")
                                {
                                    transform.position += Vector3.right;
                                    playerMove.delaySetTurn();
                                    moved = true;
                                    playEnemyStep();
                                    return;
                                }
                            }
                            transform.position += Vector3.left;
                            playerMove.delaySetTurn();
                            moved = true;
                            playEnemyStep();
                            return;
                        }
                    }
                    transform.position += Vector3.up;
                    Debug.Log("11");
                    playerMove.delaySetTurn();
                    moved = true;
                    playEnemyStep();
                    return;
                }

            }
           

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (playerMove.getMoveCount() == 3 && dead == false)
        {
            Debug.Log("Player dead!");
            playerMove.PlayerKilled();
        }
        
    }
    public void killedState()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        dead = true;
        playerMove.setEnemyDead(true);

    }
    public void playEnemyStep()
    {

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(step, 0.7f);
    }
}
