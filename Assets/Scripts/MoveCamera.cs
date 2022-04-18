using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 direction = other.transform.position - transform.position;
        //Debug.Log("Object: " + other.transform.name + " Direction: " + direction);
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("East") && direction.x > 0)
            {
                mainCamera.transform.Translate(-20f, 0, 0);
            }
            else if (gameObject.CompareTag("West") && direction.x < 0)
            {
                mainCamera.transform.Translate(20f, 0, 0);
            }
            else if (gameObject.CompareTag("South") && direction.z > 0)
            {
                mainCamera.transform.Translate(0, -20f, 0);
            }
            else if (gameObject.CompareTag("North") && direction.z < 0)
            {
                mainCamera.transform.Translate(0, 20f, 0);
            }
        }

    }
}
