using UnityEngine;
namespace Lab6
{
    public class AmmoPickup : Pickup
    {

        protected override void ApplyPickup(int amount, GameObject player)
        {
            WeaponManager weaponManager = player.GetComponent<WeaponManager>();
            Gun currentGun = weaponManager.GetGun();

        }

        protected override bool IsPickupPossible(GameObject player)
        {
            WeaponManager weaponManager = player.GetComponent<WeaponManager>();
            Gun currentGun = weaponManager.GetGun();
            return currentGun.GetAmmoReserves() < currentGun.GetMaxAmmoReserves();
        }
    }
}