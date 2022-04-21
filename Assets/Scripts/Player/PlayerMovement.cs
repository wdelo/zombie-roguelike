using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction mousePosition;

    private Plane ground;

    public void Initialize(InputAction moveAction, InputAction mousePosition)
    {
        this.moveAction = moveAction;
        this.mousePosition = mousePosition;
    }

    private void Awake()
    {
        ground = new Plane(Vector3.up, 0.0f);
    }

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
        transform.position += new Vector3(movementVector.x, 0, movementVector.y) * 4.0f * Time.deltaTime;
    }

    private void Rotate()
    {
        Vector2 mouseScreenPosition = mousePosition.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);

        float enter;
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
