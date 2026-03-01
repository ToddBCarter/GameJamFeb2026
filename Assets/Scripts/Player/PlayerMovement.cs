using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Timeline.DirectorControlPlayable;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float turnSpeed = 180f;
    [SerializeField] private string actionSet;

    private Rigidbody rb;
    private InputAction moveAction;

    private float yaw = 90f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        moveAction = InputSystem.actions.FindAction(actionSet);
    }

    private void FixedUpdate()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();

        float forwardInput = input.y;
        float turnInput = input.x;

        yaw += turnInput * turnSpeed * Time.fixedDeltaTime;
        Quaternion targetRotation = Quaternion.Euler(0f, yaw, 0f);
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 0.8f));

        Vector3 forward = transform.forward * forwardInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forward);

        rb.angularVelocity = Vector3.zero;
    }
}