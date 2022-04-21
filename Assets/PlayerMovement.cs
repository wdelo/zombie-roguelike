using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Lab6Inputs inputs;
    private InputAction moveAction;

    private Plane ground;

    private void Awake()
    {
        inputs = new Lab6Inputs();
        ground = new Plane(Vector3.up, 0.0f);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnEnable()
    {
        moveAction = inputs.Player.Move;
        moveAction.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        // Save the movement vector; x -> forward/back, y -> left/right
        Vector2 movementVector = moveAction.ReadValue<Vector2>();
        // Move the player (y is up-down so leave 0)
        transform.position += new Vector3(movementVector.x, 0, movementVector.y) * speed * Time.deltaTime;
    }

    private void Rotate()
    {
        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);

        float enter = 0.0f;
        if (ground.Raycast(ray, out enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            hitPoint.y = transform.position.y;
            Vector3 direction = hitPoint - transform.position;

            Debug.DrawRay(transform.position, direction, Color.red);
            Quaternion lookRot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, 10.0f);

        }
    }
}
