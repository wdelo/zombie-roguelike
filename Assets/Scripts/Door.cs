using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Matthew Manning */

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject doorPrefab;

    private GameObject doors;
    private RoomManager roomManager;

    private void Start()
    {
        roomManager = transform.parent.parent.gameObject.GetComponent<RoomManager>();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("hello");
        Vector3 direction = other.transform.position - transform.position;
        Debug.Log("Object: " + other.transform.name + " Direction: " + direction);
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("East") && direction.x > 0
                || gameObject.CompareTag("West") && direction.x < 0
                || gameObject.CompareTag("North") && direction.z > 0
                || gameObject.CompareTag("South") && direction.z < 0)
            {
                if (!roomManager.GetIsCleared())
                {
                    roomManager.SpawnZombies();
                    doors = Instantiate(doorPrefab, transform.parent.parent.position, transform.parent.parent.rotation);
                }
            }
        }
    }




    /*private void OnTriggerEnter(Collider other)
    {
        Vector3 direction = other.transform.position - transform.position;
        //Debug.Log("Object: " + other.transform.name + " Direction: " + direction);
        if (other.gameObject.CompareTag("Player"))
        {
            currentRoom.currentRoom = transform.parent.gameObject;
            currentRoom.SpawnZombies();

            if (gameObject.CompareTag("West") && direction.x > 0)
            {
                mainCamera.transform.Translate(-20f, 0, 0);
                //currentRoom = transform.parent.gameObject;
            }
            else if (gameObject.CompareTag("East") && direction.x < 0)
            {
                mainCamera.transform.Translate(20f, 0, 0);
            }
            else if (gameObject.CompareTag("North") && direction.z < 0)
            {
                mainCamera.transform.Translate(0, 20f, 0);
            }
            else if (gameObject.CompareTag("South") && direction.z > 0)
            {
                mainCamera.transform.Translate(0, -20f, 0);
            }
        }

    }*/
}
