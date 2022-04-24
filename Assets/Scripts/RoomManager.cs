using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;

    //private List<GameObject> zombiesInRoom = new List<GameObject>();
    private HashSet<GameObject> zombiesInRoom = new HashSet<GameObject>();

    private int maxZombies;
    private float radius;

    [SerializeField] private bool isCleared = false;

    public bool GetIsCleared()
    {
        return isCleared;
    }

    private void Start()
    {
        maxZombies = GameManager.GetInstance().maxZombiesPerRoom;
        radius = GameManager.GetInstance().radius;
    }

    /*private void Update()
    {
        Debug.Log("Length of zombie list: " + zombiesInRoom.Count);
        foreach (GameObject zombie in zombiesInRoom)
        {
            if (zombie == null) zombiesInRoom.Remove(zombie);
        }
        //if (zombiesInRoom.Count == 0) Destroy(GameObject.Find("Doors(Clone)"));
    }*/

    public void SpawnZombies()
    {
        Vector3 roomPosition = transform.position;
        int zombiesToSpawn = Random.Range(1, maxZombies + 1);

        for (int i = 0; i < zombiesToSpawn; i++)
        {
            float randCoordX = Random.Range(-radius, radius);
            float randCoordZ = Random.Range(-radius, radius);

            Quaternion randRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

            if (!Physics.CheckSphere(new Vector3(randCoordX, 1, randCoordZ) + roomPosition, 0.5f, 0, QueryTriggerInteraction.Ignore))
            {
                GameObject zombie = Instantiate(zombiePrefab, new Vector3(randCoordX, 1, randCoordZ) + roomPosition, randRotation);
                zombiesInRoom.Add(zombie);
            }
        }
        Debug.Log("Zombie Count: " + zombiesInRoom.Count);


    }

    private void CheckForDeath(GameObject deadObject)
    {
        if (deadObject == null) Debug.Log("deadobject is null");
        if (deadObject.CompareTag("Enemy") && zombiesInRoom.Contains(deadObject))
        {
            zombiesInRoom.Remove(deadObject);
            Debug.Log("Zombie Count: " + zombiesInRoom.Count);
        }
        else
        {
            Debug.Log("Not Contained");
        }
        if (zombiesInRoom.Count == 0)
        {
            Destroy(GameObject.Find("Doors(Clone)"));
            isCleared = true;
            //transform.gameObject.SetActive(false);
        }
    }

    public void OnRoomEnter()
    {
        GameManager.GetInstance().OnRoomEnter(gameObject);
        Health.onDeath += CheckForDeath;
    }

    public void OnRoomExit()
    {
        GameManager.GetInstance().OnRoomExit(gameObject);
        Health.onDeath -= CheckForDeath;
    }
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





//Debug.Log("Length: " + zombiesInRoom.Count);
/*for (int i = 0; i < zombiesInRoom.Count; i++)
{
    Debug.Log("i: " + zombiesInRoom[i].transform.name);
}*/
//Debug.Log(zombiesInRoom);



/*for (int i = 0; i < zombiesToSpawn; i++)
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
}*/