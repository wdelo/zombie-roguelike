using UnityEngine;

/* Matthew Manning and William Delo */
namespace Lab6
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;

        private GameObject currentRoom;
        private GameObject nextCurrentRoom;

        private Camera mainCamera;

        [SerializeField] public int maxZombiesPerRoom = 5;
        [SerializeField] public float radius = 1;

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
    }
}