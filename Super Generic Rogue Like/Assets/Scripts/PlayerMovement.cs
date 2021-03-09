using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if game is paused, if paused, do not allow movement
        Debug.DrawLine(transform.position, transform.position + Vector3.right, Color.white);

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {

            transform.position += Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            }
            transform.position += Vector3.right;
        }

    }
