using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Key : MonoBehaviour
{
    Tilemap tiles;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == "Player")
       {
            Debug.Log("Key obtained!");
            collision.gameObject.GetComponent<PlayerMovement>().setKeyObtained(true);
            GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>().EnableKeySprite();
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BlockTerrain")
        {
            int roomsCleared = GameObject.Find("UIController").GetComponent<UIController>().getRoomCompletedCount();
            Instantiate(this, new Vector3(roomsCleared * 12 + (Random.Range(-5, 5) + 0.5f), Random.Range(-5, 5) + 0.5f, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Key hit" + collision.gameObject.name);
    }

}
