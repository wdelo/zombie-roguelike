using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    //[SerializeField] private GameObject mainCamera;

    private void OnTriggerEnter(Collider other)
    {
        Vector3 direction = other.transform.position - transform.position;
        //Debug.Log("Object: " + other.transform.name + " Direction: " + direction);
        //if (gameObject.CompareTag("East") && direction )
        {

        }
    }
}
