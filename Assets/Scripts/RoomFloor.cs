using UnityEngine;

/* Matthew Manning and William Delo */

namespace Lab6
{
    public class RoomFloor : MonoBehaviour
    {
        private GameObject room;
        private RoomManager roomManager;

        private void Awake()
        {
            room = transform.parent.gameObject;
            roomManager = room.GetComponent<RoomManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag != null && other.gameObject.CompareTag("Player"))
            {
                roomManager.OnRoomEnter();

            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag != null && other.gameObject.CompareTag("Player"))
            {
                roomManager.OnRoomExit();
            }
        }
    }
}
