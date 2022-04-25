using UnityEngine;
using UnityEngine.InputSystem;

namespace Lab6
{
    public class WeaponManager : MonoBehaviour
    {
        private InputAction fireAction;
        private InputAction reloadAction;

        private Gun gun;

        public void Initialize(InputAction fireAction, InputAction reloadAction)
        {
            this.fireAction = fireAction;
            this.reloadAction = reloadAction;
        }

        private void Awake()
        {
            gun = GetComponentInChildren<Gun>();
        }

        public Gun GetGun()
        {
            return gun;
        }

        public void StartFire(InputAction.CallbackContext obj)
        {
            //Debug.Log("Started firing");
            gun.StartShooting();
        }

        public void CancelFire(InputAction.CallbackContext obj)
        {
            //Debug.Log("Stopped firing");
            gun.StopShooting();
        }

        public void Reload(InputAction.CallbackContext obj)
        {
            gun.StartReloading();
        }

    }
}