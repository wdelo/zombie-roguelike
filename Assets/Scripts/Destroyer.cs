using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Matthew Manning */

namespace Lab6
{
    public class Destroyer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("SpawnPoint"))
            {
                Destroy(other.gameObject);
            }

        }
    }
}