using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name + ": " + other.gameObject.tag);
        if (other.gameObject.CompareTag("RoomPrefab"))
        {
            //Debug.Log("hello");
            Destroy(other.gameObject);
        }
        
    }
}
