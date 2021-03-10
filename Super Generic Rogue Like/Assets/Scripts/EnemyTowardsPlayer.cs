﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTowardsPlayer : MonoBehaviour
{

    GameObject player;
    PlayerMovement playerMove;
    RaycastHit2D hit;
    [SerializeField]
    Sprite[] sprites = new Sprite[2]; //Sprite 0 is default state, sprite 1 is dead.
    bool dead = false;
    bool moved = false;
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
        if (playerMove.getTurn())
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
                        if (hit = Physics2D.Raycast(transform.position + Vector3.right, Vector2.right, 0.5f))
                        {
                            if (hit.collider.gameObject.tag == "BlockTerrain") //if the player is directly to the right, but behind terrain, check if up or down is free.
                            {
                                if (hit = Physics2D.Raycast(transform.position + Vector3.down, Vector2.down, 0.5f)) //Prefer going down, if down is blocked, go up.
                                {
                                    if (hit.collider.gameObject.tag == "BlockTerrain")
                                    {
                                        transform.position += Vector3.up;
                                        playerMove.delaySetTurn();
                                        moved = true;
                                        return;
                                    }
                                }
                                else
                                {
                                    transform.position += Vector3.down;
                                    playerMove.delaySetTurn();
                                    moved = true;
                                    return;
                                }

                            }
                        }
                        transform.position += Vector3.right;
                        Debug.Log(0);
                        playerMove.delaySetTurn();
                        moved = true;
                        return;
                    }
                    if (Gap.y > 0)
                    {
                        if (Roll == 0)
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.right, Vector2.right, 0.5f)) //if the right is blocked, go down.
                            {
                                transform.position += Vector3.down;
                                Debug.Log("2");
                                playerMove.delaySetTurn();
                                moved = true;
                                return;
                            }
                            transform.position += Vector3.right;
                            Debug.Log("1");
                            playerMove.delaySetTurn();
                            moved = true;
                            return;
                        }
                        else
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.down, Vector2.down, 0.5f)) //If the down is blocked, go right.
                            {
                                transform.position += Vector3.right;
                                playerMove.delaySetTurn();
                                moved = true;
                                return;
                            }
                            transform.position += Vector3.down;
                            Debug.Log("2");
                            playerMove.delaySetTurn();
                            moved = true;
                            return;
                        }
                    }
                    else
                    {
                        if (Roll == 0)
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.right, Vector2.right, 0.5f)) //If the right is blocked, go up.
                            {
                                transform.position += Vector3.up;
                                playerMove.delaySetTurn();
                                moved = true;
                                return;
                            }
                            transform.position += Vector3.right;
                            Debug.Log("3");
                            playerMove.delaySetTurn();
                            moved = true;
                            return;
                        }
                        else
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.up, Vector2.up, 0.5f)) //If the up is blocked, go right.
                            {
                                transform.position += Vector3.up;
                                playerMove.delaySetTurn();
                                moved = true;
                                return;
                            }
                            transform.position += Vector3.up;
                            Debug.Log("4");
                            playerMove.delaySetTurn();
                            moved = true;
                            return;
                        }
                    }

                }
                else //x > 0
                {
                    if (Gap.y == 0)
                    {
                        if (hit = Physics2D.Raycast(transform.position + Vector3.left, Vector2.left, 0.5f)) //If the left is blocked, check if down is blocked. 
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.down, Vector2.down, 0.5f)) //Prefer going down, if down is blocked, go up.
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain")
                                {
                                    transform.position += Vector3.up;
                                    playerMove.delaySetTurn();
                                    moved = true;
                                    return;
                                }
                            }
                            else
                            {
                                transform.position += Vector3.down;
                                playerMove.delaySetTurn();
                                moved = true;
                                return;
                            }
                        }
                        transform.position += Vector3.left;
                        Debug.Log("5");
                        playerMove.delaySetTurn();
                        moved = true;
                        return;
                    }

                    if (Gap.y > 0)
                    {
                        if (Roll == 0)
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.left, Vector2.left, 0.5f)) //if left is blocked, go down.
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain")
                                {
                                    transform.position += Vector3.down;
                                    playerMove.delaySetTurn();
                                    moved = true;
                                    return;
                                }
                            }
                            transform.position += Vector3.left;
                            Debug.Log("6");
                            playerMove.delaySetTurn();
                            moved = true;
                            return;
                        }
                        else
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.down, Vector2.down, 0.5f)) //if down is blocked, go left.
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain")
                                {
                                    transform.position += Vector3.left;
                                    playerMove.delaySetTurn();
                                    moved = true;
                                    return;
                                }
                            }
                            transform.position += Vector3.down;
                            Debug.Log("7");
                            playerMove.delaySetTurn();
                            moved = true;
                            return;
                        }
                    }
                    else
                    {
                        if (Roll == 0)
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.left, Vector2.left, 0.5f)) //if left is blocked, go up.
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain")
                                {
                                    transform.position += Vector3.up;
                                    playerMove.delaySetTurn();
                                    moved = true;
                                    return;
                                }
                            }
                            transform.position += Vector3.left;
                            Debug.Log("8");
                            playerMove.delaySetTurn();
                            moved = true;
                            return;
                        }
                        else
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.up, Vector2.up, 0.5f)) //if up is blocked, go left.
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain")
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
                            return;
                        }
                    }
                }
            }
            else
            {
                //Determine if above or below, move towards.
                if (Gap.y > 0)
                {
                    if (hit = Physics2D.Raycast(transform.position + Vector3.down, Vector2.down, 0.5f)) //if down is blocked, check left
                    {
                        if (hit.collider.gameObject.tag == "BlockTerrain")
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.down, Vector2.down, 0.5f)) //if left is blocked, go right.
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain")
                                {
                                    transform.position += Vector3.right;
                                    playerMove.delaySetTurn();
                                    moved = true;
                                    return;
                                }
                            }
                            else
                            {
                                transform.position += Vector3.left;
                                playerMove.delaySetTurn();
                                moved = true;
                                return;
                            }
                        }
                    }
                    transform.position += Vector3.down;
                    Debug.Log("10");
                    playerMove.delaySetTurn();
                    moved = true;
                    return;
                }
                else
                {
                    if (hit = Physics2D.Raycast(transform.position + Vector3.up, Vector2.up, 0.5f)) //if up is blocked, check left.
                    {
                        if (hit.collider.gameObject.tag == "BlockTerrain")
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.down, Vector2.down, 0.5f)) //if left is blocked, go right.
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain")
                                {
                                    transform.position += Vector3.right;
                                    playerMove.delaySetTurn();
                                    moved = true;
                                    return;
                                }
                            }
                            else
                            {
                                transform.position += Vector3.left;
                                playerMove.delaySetTurn();
                                moved = true;
                                return;
                            }
                        }
                    }
                    transform.position += Vector3.up;
                    Debug.Log("11");
                    playerMove.delaySetTurn();
                    moved = true;
                    return;
                }

            }
           

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (playerMove.getMoveCount() == 0 && !playerMove.getTurn())
        {
            Debug.Log("Player dead!");
            playerMove.PlayerKilled();
        }
        
    }
    public void killedState()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        dead = true;

    }
}
