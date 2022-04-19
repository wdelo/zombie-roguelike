using UnityEngine;

// Testing script: will delete later
public class TakeDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().DecreaseHealth(5);
            Debug.Log(other.gameObject + " damaged by 5");
        }

    }
}
