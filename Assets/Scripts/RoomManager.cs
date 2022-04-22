using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

}


/*[SerializeField] public GameObject currentRoom;
[SerializeField] private GameObject zombiePrefab;
[SerializeField] private int maxZombies = 5;
[SerializeField] private float radius = 8;

private List<GameObject> zombiesInRoom = new List<GameObject>();

public void SpawnZombies()
{
    Vector3 roomPosition = currentRoom.transform.position;
    int zombiesToSpawn = Random.Range(1, maxZombies + 1);

    for (int i = 0; i < zombiesToSpawn; i++)
    {
        float randCoordX = Random.Range(-radius, radius);
        float randCoordZ = Random.Range(-radius, radius);

        Quaternion randRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
        while (Physics.CheckSphere(new Vector3(randCoordX, 1, randCoordZ) + roomPosition, 0.5f))
        {
            randCoordX = Random.Range(-radius, radius);
            randCoordZ = Random.Range(-radius, radius);
        }

        GameObject zombie = Instantiate(zombiePrefab, new Vector3(randCoordX, 1, randCoordZ) + roomPosition, randRotation);
        zombiesInRoom.Add(zombie);
    }
}*/