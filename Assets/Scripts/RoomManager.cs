using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Matthew Manning and William Delo */

namespace Lab6
{
    public class RoomManager : MonoBehaviour
    {
        [SerializeField] private GameObject zombiePrefab;
        [SerializeField] private GameObject[] pickupPrefabs;

        private HashSet<GameObject> zombiesInRoom = new HashSet<GameObject>();

        private int maxZombies;
        private int maxPickups;
        private float radius;

        [SerializeField] private bool isCleared = false;

        public bool GetIsCleared()
        {
            return isCleared;
        }

        private void Start()
        {
            maxZombies = GameManager.GetInstance().maxZombiesPerRoom;
            maxPickups = GameManager.GetInstance().maxPickupsPerRoom;
            radius = GameManager.GetInstance().radius;
        }

        public void SetUpRoom()
        {
            SpawnZombies();
            SpawnPickups();
        }

        private GameObject SpawnInRoom(GameObject objectToSpawn)
        {
            float randCoordX = Random.Range(-radius, radius);
            float randCoordZ = Random.Range(-radius, radius);

            Quaternion randRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

            GameObject spawnedObject = null;
            if (!Physics.CheckSphere(new Vector3(randCoordX, 1, randCoordZ) + transform.position, 0.5f, 0, QueryTriggerInteraction.Ignore))
            {
                spawnedObject = Instantiate(objectToSpawn, new Vector3(randCoordX, 1, randCoordZ) + transform.position, randRotation);
            }

            return spawnedObject;
        }

        private void SpawnZombies()
        {
            int zombiesToSpawn = Random.Range(1, maxZombies+1);
            int zombiesSpawned = 0;
            while (zombiesSpawned < zombiesToSpawn)
            { 
                GameObject zombie = SpawnInRoom(zombiePrefab);
                if (zombie != null)
                {
                    zombiesSpawned++;
                    zombiesInRoom.Add(zombie);
                }
            }
        }

        private void SpawnPickups()
        {
            int pickupsToSpawn = Random.Range(0, maxPickups+1);
            int pickupsSpawned = 0;
            while (pickupsSpawned < pickupsToSpawn)
            {
                GameObject pickup = SpawnInRoom(pickupPrefabs[Random.Range(0, pickupPrefabs.Length)]);
                if (pickup != null)
                {
                    pickupsSpawned++;
                }
            }
        }

        private void CheckForDeath(GameObject deadObject)
        {
            if (deadObject.CompareTag("Enemy") && zombiesInRoom.Contains(deadObject))
            {
                zombiesInRoom.Remove(deadObject);
                Debug.Log("Zombie Count: " + zombiesInRoom.Count);
            }
            if (zombiesInRoom.Count == 0)
            {
                Destroy(GameObject.Find("Doors(Clone)"));
                isCleared = true;
                GameManager.GetInstance().CheckForLevelComplete();
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
}