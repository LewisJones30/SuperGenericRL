using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] sprites;
    public float timer;
    public int timerRounded;
    SpriteRenderer s;
    EnemyTowardsPlayer deadCheck;
    EnemyRandomMovement deadCheck1;
    PlayerMovement playerDeadCheck;
    void Start()
    {
        s = GetComponent<SpriteRenderer>();

        switch (this.tag)
        { case"EnemyLocator":
                deadCheck = GetComponent<EnemyTowardsPlayer>();
                break;
            case "EnemyRandom":
                deadCheck1 = GetComponent<EnemyRandomMovement>();
                break;
            case "Player":
                playerDeadCheck = GetComponent<PlayerMovement>();
                break;
            default:
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (deadCheck != null)
        {
            if (!deadCheck.dead)
            {
                timer += Time.deltaTime;
                timerRounded = Convert.ToInt32(timer);
                s.sprite = sprites[timerRounded];

                if (timer > 1.4f)
                {
                    timer = -.5f;
                }
            }

        }
        if (deadCheck1 != null)
        {
            if (!deadCheck1.dead)
            {
                timer += Time.deltaTime;
                timerRounded = Convert.ToInt32(timer);
                s.sprite = sprites[timerRounded];

                if (timer > 1.4f)
                {
                    timer = -.5f;
                }
            }
        }
        if (playerDeadCheck != null)
        {
            if (!playerDeadCheck.isDead )
            {
                timer += Time.deltaTime;
                timerRounded = Convert.ToInt32(timer);
                s.sprite = sprites[timerRounded];

                if (timer > 1.4f)
                {
                    timer = -.5f;
                }
            }

        }

    }
}
