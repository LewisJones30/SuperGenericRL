using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTowardsPlayer : MonoBehaviour
{

    GameObject player;
    PlayerMovement playerMove;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMove = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        int Roll;


        if (player != null && !playerMove.getTurn())
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
                        transform.position += Vector3.right;
                        Debug.Log(0);
                        playerMove.setTurn(true);
                        return;
                    }
                    if (Gap.y > 0)
                    {
                        if (Roll == 0)
                        {
                            transform.position += Vector3.right;
                            Debug.Log("1");
                            playerMove.setTurn(true);
                            return;
                        }
                        else
                        {
                            transform.position += Vector3.down;
                            Debug.Log("2");
                            playerMove.setTurn(true);
                            return;
                        }
                    }
                    else
                    {
                        if (Roll == 0)
                        {
                            transform.position += Vector3.right;
                            Debug.Log("3");
                            playerMove.setTurn(true);
                            return;
                        }
                        else
                        {
                            transform.position += Vector3.up;
                            Debug.Log("4");
                            playerMove.setTurn(true);
                            return;
                        }
                    }

                }
                else //x > 0
                {
                    if (Gap.y == 0)
                    {
                        transform.position += Vector3.left;
                        Debug.Log("5");
                        playerMove.setTurn(true);
                        return;
                    }

                    if (Gap.y > 0)
                    {
                        if (Roll == 0)
                        {
                            transform.position += Vector3.left;
                            Debug.Log("6");
                            playerMove.setTurn(true);
                            return;
                        }
                        else
                        {
                            transform.position += Vector3.down;
                            Debug.Log("7");
                            playerMove.setTurn(true);
                            return;
                        }
                    }
                    else
                    {
                        if (Roll == 0)
                        {
                            transform.position += Vector3.left;
                            Debug.Log("8");
                            playerMove.setTurn(true);
                            return;
                        }
                        else
                        {
                            transform.position += Vector3.up;
                            Debug.Log("9");
                            playerMove.setTurn(true);
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
                    transform.position += Vector3.down;
                    Debug.Log("10");
                    playerMove.setTurn(true);
                    return;
                }
                else
                {
                    transform.position += Vector3.up;
                    Debug.Log("11");
                    playerMove.setTurn(true);
                    return;
                }

            }
           

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (playerMove.getTurn())
        {
            Debug.Log("Player dead!");
            playerMove.PlayerKilled();
        }
    }
}
