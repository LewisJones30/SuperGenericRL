using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomMovement : MonoBehaviour
{
    PlayerMovement Player;
    System.Random Rand = new System.Random();
    RaycastHit2D hit;
    [SerializeField]
    Sprite[] sprites = new Sprite[2];
    bool dead = false;
    bool moved = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        moved = false;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.getTurn() && dead == false)
        {
            moved = false;
            Player.setEnemyDead(false);
        }
        if (!Player.getTurn() && dead == false && moved == false)
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
                                if (hit.collider.gameObject.tag == "BlockTerrain" || hit.collider.gameObject.tag == "EnemyRandom" || hit.collider.gameObject.tag == "EnemyLocator")
                                {
                                    return;
                                }
                            }
                            transform.position += Vector3.up;
                            Player.delaySetTurn();
                            moved = true;
                            return;
                        }
                    case 1:
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.left, Vector2.left, 0.5f))
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain" || hit.collider.gameObject.tag == "EnemyRandom" || hit.collider.gameObject.tag == "EnemyLocator")
                                {
                                    return;
                                }
                            }
                            transform.position += Vector3.left;
                            Player.delaySetTurn();
                            moved = true;
                            return;
                        }
                    case 2:
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.down, Vector2.down, 0.5f))
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain" || hit.collider.gameObject.tag == "EnemyRandom" || hit.collider.gameObject.tag == "EnemyLocator")
                                {
                                    return;
                                }
                            }
                            transform.position += Vector3.down;
                            Player.delaySetTurn();
                            moved = true;
                            return;
                        }
                    case 3:
                        {
                            if (hit = Physics2D.Raycast(transform.position + Vector3.right, Vector2.right, 0.5f))
                            {
                                if (hit.collider.gameObject.tag == "BlockTerrain" || hit.collider.gameObject.tag == "EnemyRandom" || hit.collider.gameObject.tag == "EnemyLocator")
                                {
                                    return;
                                }
                            }
                            transform.position += Vector3.right;
                            Player.delaySetTurn();
                            moved = true;
                            return;
                        }
                }
            }
           
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (Player.getMoveCount() == 3 && dead == false) 
        {
            Debug.Log("Player dead!");
            Player.PlayerKilled();
        }

    }
    public void killedState()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        dead = true;
        Player.setEnemyDead(true);
    }
}
