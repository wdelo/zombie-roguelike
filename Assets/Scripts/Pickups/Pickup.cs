using UnityEngine;

/* William Delo */

namespace Lab6
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(BoxCollider))]
    public abstract class Pickup : MonoBehaviour
    {
        [SerializeField]
        [Min(0)]
        private int amount;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PerformPickup(other.gameObject);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PerformPickup(other.gameObject);
            }
        }

        private void PerformPickup(GameObject player)
        {
            if (IsPickupPossible(player))
            {
                AudioSource audioSource = GetComponent<AudioSource>();
                GetComponent<BoxCollider>().enabled = false;
                ApplyPickup(amount, player);
                if (audioSource.clip != null)
                {
                    AudioSource.PlayClipAtPoint(audioSource.clip, transform.position, audioSource.volume);
                }
                Destroy(gameObject);
            }
        }

        protected abstract void ApplyPickup(int amount, GameObject player);

        protected abstract bool IsPickupPossible(GameObject player);

    }
}