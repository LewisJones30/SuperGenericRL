using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class loadNewRoom : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] mapTiles;
   
    public GameObject enemyTowards;
    public GameObject keyObj;
    public GameObject enemyRandom;
    public Camera mainCam;
    bool keyLoadedCorrectly = false;
    int roomClearCount;
    public void loadNextTile(int roomsCleared)
    {
        keyLoadedCorrectly = false;
        roomClearCount = roomsCleared;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().setEnemyDead(false);
        GameObject test = Instantiate(mapTiles[Random.Range(0, mapTiles.Length)], new Vector3(roomsCleared * 12, 0, 0), Quaternion.identity);
        //Debug.Log("here 2");
        while (!keyLoadedCorrectly)
        {
            GameObject test5 = Instantiate(keyObj, new Vector3(roomsCleared * 12 + (Random.Range(-5, 5) + 0.5f), Random.Range(-5, 5) + 0.5f, 0), Quaternion.identity);
            Tilemap test1 = test.transform.Find("BlockTerrain").GetComponent<Tilemap>();
            Vector3 test4 = new Vector3(test5.transform.position.x - (roomsCleared * 12) - 0.5f, (test5.transform.position.y), 0);
            Vector3Int test3 = Vector3Int.FloorToInt(test4);
            var test2 = test1.GetTile(test3);
            if (test2 != null)
            {
                Debug.Log("Woo!");
                Destroy(test5);
            }
            else
            {
                Debug.Log("Woo 2!");
                keyLoadedCorrectly = true;
            }
        }
        int numberOfEnemies = Random.Range(roomsCleared + 1, roomsCleared + 3); //Added one due to range issue.
        if (numberOfEnemies > 10)
        {
            numberOfEnemies = 10;
        }
        for (int i = 0; i < numberOfEnemies; i++)
        {
            bool enemyLoadedCorrectly = false;
            while (!enemyLoadedCorrectly)
            {
                int enemyType = Random.Range(0, 2);
                if (enemyType == 0)
                {
                    GameObject test5 = Instantiate(enemyRandom, new Vector3(roomsCleared * 12 + (Random.Range(-3, 5) + 0.5f), Random.Range(-5, 5) + 0.5f, 0), Quaternion.identity);
                    Tilemap test1 = test.transform.Find("BlockTerrain").GetComponent<Tilemap>();
                    Vector3 test4 = new Vector3(test5.transform.position.x - (roomsCleared * 12) - 0.5f, (test5.transform.position.y), 0);
                    Vector3Int test3 = Vector3Int.FloorToInt(test4);
                    var test2 = test1.GetTile(test3);
                    if (test2 != null)
                    {
                        Debug.Log("Woo!");
                        Destroy(test5);
                    }
                    else
                    {
                        Debug.Log("Woo 2!");
                        enemyLoadedCorrectly = true;
                    }
                }
                else
                {
                    GameObject test5 = Instantiate(enemyTowards, new Vector3(roomsCleared * 12 + (Random.Range(-3, 5) + 0.5f), Random.Range(-5, 5) + 0.5f, 0), Quaternion.identity);
                    Tilemap test1 = test.transform.Find("BlockTerrain").GetComponent<Tilemap>();
                    Vector3 test4 = new Vector3(test5.transform.position.x - (roomsCleared * 12) - 0.5f, (test5.transform.position.y), 0);
                    Vector3Int test3 = Vector3Int.FloorToInt(test4);
                    var test2 = test1.GetTile(test3);
                    if (test2 != null)
                    {
                        Debug.Log("Woo!");
                        Destroy(test5);
                    }
                    else
                    {
                        Debug.Log("Woo 2!");
                        enemyLoadedCorrectly = true;
                    }
                }
            }
        }
    }
    private void Update()
    {
        mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, new Vector3(roomClearCount * 12, 0f, -10f), Time.deltaTime *3);

       // mainCam.transform.position = new Vector3(roomClearCount * 12, 0, -10);
    }
}
