using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Matthew Manning */
namespace Lab6
{
    public class RoomTemplate : MonoBehaviour
    {
        [SerializeField] public GameObject[] bottomRooms;
        [SerializeField] public GameObject[] topRooms;
        [SerializeField] public GameObject[] leftRooms;
        [SerializeField] public GameObject[] rightRooms;

        public GameObject closedRoom;
    }
}