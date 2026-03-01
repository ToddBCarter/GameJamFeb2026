using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float turnSpeed = 180f;

    private Rigidbody rb;
    private InputAction moveAction;

    private float yaw = 90f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void FixedUpdate()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();

        float forwardInput = input.y;
        float turnInput = input.x;

        yaw += turnInput * turnSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(Quaternion.Euler(0f, yaw, 0f));

        Vector3 forward = transform.forward * forwardInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forward);

        rb.angularVelocity = Vector3.zero;
    }
}