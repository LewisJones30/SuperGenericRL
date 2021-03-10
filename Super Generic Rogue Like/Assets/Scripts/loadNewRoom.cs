using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadNewRoom : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] mapTiles;

    public Camera mainCam;

    int roomClearCount;
    public void loadNextTile(int roomsCleared)
    {
        roomClearCount = roomsCleared;
        //Debug.Log("here 2");
        Instantiate(mapTiles[Random.Range(0, 2)], new Vector3(roomsCleared * 12, 0, 0), Quaternion.identity);
    }
    private void Update()
    {
        mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, new Vector3(roomClearCount * 12, 0f, -10f), Time.deltaTime);

       // mainCam.transform.position = new Vector3(roomClearCount * 12, 0, -10);
    }
}
