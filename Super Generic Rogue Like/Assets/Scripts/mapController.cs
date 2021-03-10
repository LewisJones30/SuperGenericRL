using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapController : MonoBehaviour
{

    public GameObject[] mapRooms;

    public void loadNewRoom(int numberOfRoomsCleared)
    {
        Instantiate(mapRooms[Random.Range(0, 2)], new Vector3(numberOfRoomsCleared * 12, 0, 0), Quaternion.identity);
    }
}
