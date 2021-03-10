using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomMovement : MonoBehaviour
{
    PlayerMovement Player;
    System.Random Rand = new System.Random();
    RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.getTurn())
        {
            while (!Player.getTurn())
            {
                int Direction = Rand.Next(0, 3);
                switch (Direction)
                {
                    case 0:
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.up, Vector2.up, 0.5f))
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain")
                                {
                                    return;
                                }
                            }
                            transform.position += Vector3.up;
                            Player.setTurn(true);
                            return;
                        }
                    case 1:
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.left, Vector2.left, 0.5f))
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain")
                                {
                                    return;
                                }
                            }
                            transform.position += Vector3.left;
                            Player.setTurn(true);
                            return;
                        }
                    case 2:
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.down, Vector2.down, 0.5f))
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain")
                                {
                                    return;
                                }
                            }
                            transform.position += Vector3.down;
                            Player.setTurn(true);
                            return;
                        }
                    case 3:
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.right, Vector2.right, 0.5f))
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain")
                                {
                                    return;
                                }
                            }
                            transform.position += Vector3.right;
                            Player.setTurn(true);
                            return;
                        }
                }
            }
           
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (Player.getTurn())
        {
            Debug.Log("Player dead!");
            Player.PlayerKilled();
        }
    }
}
