using UnityEngine;

namespace Lab6
{
    public class HealthPickup : Pickup
    {

        protected override void ApplyPickup(int amount, GameObject player)
        {
            Health playerHealth = player.GetComponent<Health>();
            playerHealth.IncreaseHealth(amount);
        }

        protected override bool IsPickupPossible(GameObject player)
        {
            Health playerHealth = player.GetComponent<Health>();
            return playerHealth.GetHealth() < playerHealth.GetMaxHealth();
        }
    }
}