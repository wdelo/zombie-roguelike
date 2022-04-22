using UnityEngine;

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
            GameManager.GetInstance().OnRoomEnter(room);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != null && other.gameObject.CompareTag("Player"))
        {
            GameManager.GetInstance().OnRoomExit(room);
        }
    }
}
