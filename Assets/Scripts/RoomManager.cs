using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Matthew Manning */

namespace Lab6
{
    public class RoomManager : MonoBehaviour
    {
        [SerializeField] private GameObject zombiePrefab;

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