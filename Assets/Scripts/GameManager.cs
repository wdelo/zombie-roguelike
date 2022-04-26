using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Matthew Manning and William Delo */
namespace Lab6
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;

        private GameObject currentRoom;
        private GameObject nextCurrentRoom;
        private int score;
        private int roomsCleared;
        private int totalRoomsInLevel;
        private Camera mainCamera;

        [SerializeField] public int maxZombiesPerRoom = 5;
        [SerializeField] public int maxPickupsPerRoom = 2;
        [SerializeField] public float radius = 1;

        private void OnEnable()
        {
            Health.onDeath += IncreaseScore;
            Health.onDeath += PlayerDied;
        }

        private void OnDisable()
        {
            Health.onDeath -= IncreaseScore;
            Health.onDeath -= PlayerDied;
        }
        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
            score = 0;
            roomsCleared = 1;
            totalRoomsInLevel = 0;
            mainCamera = Camera.main;
        }

        public static GameManager GetInstance()
        {
            return instance;
        }
        public void OnRoomEnter(GameObject room)
        {
            nextCurrentRoom = room;

            if (currentRoom == null)
            {
                currentRoom = nextCurrentRoom;
                nextCurrentRoom = null;
                mainCamera.transform.position = currentRoom.transform.GetChild(0).position;
            }
        }

        public void OnRoomExit(GameObject room)
        {
            currentRoom = null;

            if (nextCurrentRoom != null)
            {
                currentRoom = nextCurrentRoom;
                nextCurrentRoom = null;
                mainCamera.transform.position = currentRoom.transform.GetChild(0).position;
            }
        }
        private void PlayerDied(GameObject obj)
        {
            if (obj.CompareTag("Player"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
                
        }
        private void IncreaseScore(GameObject obj)
        {
            if (obj.CompareTag("Enemy"))
                score += 100;

        }
        public int GetScore()
        {
            return score;
        }

        public void IncrementRoomCount()
        {
            totalRoomsInLevel++;
            Debug.Log(totalRoomsInLevel);
        }

        public void DecrementRoomCount()
        {
            totalRoomsInLevel--;
            Debug.Log(totalRoomsInLevel);
        }

        public void CheckForLevelComplete()
        {
            roomsCleared++;

            if (roomsCleared >= totalRoomsInLevel)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}