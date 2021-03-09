using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomMovement : MonoBehaviour
{
    PlayerMovement Player;
    System.Random Rand = new System.Random();
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
            int Direction = Rand.Next(0, 3);
            switch (Direction)
            {
                case 0:
                    {
                        transform.position += Vector3.up;
                        Player.setTurn(true);
                        return;
                    }
                case 1:
                    {
                        transform.position += Vector3.left;
                        Player.setTurn(true);
                        return;
                    }
                case 2:
                    {
                        transform.position += Vector3.down;
                        Player.setTurn(true);
                        return;
                    }
                case 3:
                    {
                        transform.position += Vector3.right;
                        Player.setTurn(true);
                        return;
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
            Destroy(collision.gameObject);
        }
    }
}
