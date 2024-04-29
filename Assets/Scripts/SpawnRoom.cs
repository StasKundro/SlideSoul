using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    public GameObject[] room;
    public GameObject end;
    public int maxRooms = 10;
    private int x = 0;
    public Transform targ;

    private void Update()
    {

        if(x < maxRooms)
        {
            x++;
            Instantiate(room[Random.Range(0, room.Length)], targ.position, Quaternion.identity);
            targ.position = new Vector3(targ.position.x, targ.position.y + 6f, targ.position.z);
        }
        if( x == maxRooms)
        {
            x++;
            Instantiate(end, targ.position, Quaternion.identity);
        }
    }
}
