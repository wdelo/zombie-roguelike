using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] private int openingDirection;

    private RoomTemplate templates;
    private int randomNum;
    private bool spawned = false;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        Invoke("Spawn", 0.1f);
    }

    private void Spawn()
    {
        if (spawned == false)
        {
            switch (openingDirection)
            {
                case (1):
                    randomNum = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[randomNum], transform.position, templates.bottomRooms[randomNum].transform.rotation);
                    break;
                case (2):
                    randomNum = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[randomNum], transform.position, templates.topRooms[randomNum].transform.rotation);
                    break;
                case (3):
                    randomNum = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[randomNum], transform.position, templates.leftRooms[randomNum].transform.rotation);
                    break;
                case (4):
                    randomNum = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[randomNum], transform.position, templates.rightRooms[randomNum].transform.rotation);
                    break;
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
            
        }
    }
}
