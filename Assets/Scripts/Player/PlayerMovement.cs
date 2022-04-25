using UnityEngine;
using UnityEngine.InputSystem;

namespace Lab6
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;

        private Animator animator;

        private InputAction moveAction;
        private InputAction mousePosition;

    private Plane ground;
    private LineRenderer line;

        public void Initialize(InputAction moveAction, InputAction mousePosition)
        {
            this.moveAction = moveAction;
            this.mousePosition = mousePosition;
        }

    private void Awake()
    {
        ground = new Plane(Vector3.up, 0.0f);
        line = GetComponent<LineRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

        void Update()
        {
            Move();
            Rotate();
        }

    private void Move()
    {
        Vector2 inputVector = moveAction.ReadValue<Vector2>();
        Vector3 movementVector = new Vector3(inputVector.x, 0, inputVector.y);
        movementVector.Normalize();
        transform.position += movementVector * speed * Time.deltaTime;
        line.SetPosition(0, transform.position);
        AnimateMove(movementVector);
    }

        private void AnimateMove(Vector3 movement)
        {
            float velocityX = Vector3.Dot(movement, transform.right);
            float velocityZ = Vector3.Dot(movement, transform.forward);

            animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);
            animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
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
                line.SetPosition(1, hitPoint);
                Quaternion lookRot = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, 10.0f);
            }
        }
    }

}
