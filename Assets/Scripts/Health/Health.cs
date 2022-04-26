using UnityEngine;

/* William Delo */

namespace Lab6
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        [Min(0)]
        private int maxHealth;
        private int currentHealth;

        public delegate void OnDeath(GameObject deadObject);
        public static OnDeath onDeath;

        private void Awake()
        {
            ResetHealth();
        }

        public int GetMaxHealth()
        {
            return maxHealth;
        }

        public int GetHealth()
        {
            return currentHealth;
        }

        public void DecreaseHealth(int amount)
        {
            currentHealth -= amount;

            if (currentHealth <= 0)
            {
                Kill();
            }
        }
        public void IncreaseHealth(int amount)
        {
            currentHealth += amount;

            if (currentHealth >= maxHealth)
            {
                ResetHealth();
            }
        }

        public void ResetHealth()
        {
            currentHealth = maxHealth;
        }

        protected virtual void Kill()
        {
            onDeath?.Invoke(gameObject);
            Destroy(gameObject);
        }
    }
}