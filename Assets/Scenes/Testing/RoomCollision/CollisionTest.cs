using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLLISION DETECTED!");
        Destroy(transform.parent.gameObject);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("TRIGGER DETECTED!");
        Destroy(transform.parent.gameObject);
    }

}
