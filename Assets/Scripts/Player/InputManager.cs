using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Lab6Inputs inputs;

    private PlayerMovement movement;
    private WeaponManager weaponManager;

    private void Awake()
    {
        inputs = new Lab6Inputs();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        movement = GetComponent<PlayerMovement>();
        weaponManager = GetComponent<WeaponManager>();

        InitializeInputs();
    }

    private void InitializeInputs()
    {
        movement.Initialize(inputs.Player.Move, inputs.Player.MousePosition);
        weaponManager.Initialize(inputs.Player.Fire, inputs.Player.Reload);
    }

    private void OnEnable()
    {
        inputs.Player.Move.Enable();
        inputs.Player.MousePosition.Enable();

        inputs.Player.Fire.started += weaponManager.StartFire;
        inputs.Player.Fire.canceled += weaponManager.CancelFire;
        inputs.Player.Reload.performed += weaponManager.Reload;
        inputs.Player.Fire.Enable();
        inputs.Player.Reload.Enable();
    }

    private void OnDisable()
    {
        inputs.Player.Move.Disable();
        inputs.Player.MousePosition.Disable();

        inputs.Player.Fire.started -= weaponManager.StartFire;
        inputs.Player.Fire.canceled -= weaponManager.CancelFire;
        inputs.Player.Reload.performed -= weaponManager.Reload;
        inputs.Player.Fire.Disable();
        inputs.Player.Reload.Disable();
    }
}
