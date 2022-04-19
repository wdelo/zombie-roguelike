using UnityEngine;

public class AmmoPickup : Pickup
{

    protected override void ApplyPickup(int amount, GameObject player)
    {
        // Get player's ammo and give ammo
    }

    protected override bool IsPickupPossible(GameObject player)
    {
        // Get player's ammo and check if full 
        return true;
    }
}
