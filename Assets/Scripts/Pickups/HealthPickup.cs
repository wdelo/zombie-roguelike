using UnityEngine;

public class HealthPickup : Pickup
{

    protected override void ApplyPickup(int amount, GameObject player)
    {
        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.IncreaseHealth(amount);
            Debug.Log("Gave player " + amount);
        }
    }
    protected override bool IsPickupPossible(GameObject player)
    {
        Health playerHealth = player.GetComponent<Health>();
        return playerHealth.GetHealth() < playerHealth.GetMaxHealth();
    }
}
