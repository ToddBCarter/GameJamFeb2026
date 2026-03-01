using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Timeline.DirectorControlPlayable;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float turnSpeed = 80f;
    [SerializeField] private string actionSet;

    private AudioSource engineSource;
    public float minPitch = 0.2f; // Sound when stopped
    public float maxPitch = 2.5f; // Sound at top speed

    private Rigidbody rb;
    private InputAction moveAction;

    private float speedMultiplier = 1f;
    private float slowTimer = 0f;

    private float yaw = 90f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        engineSource = GetComponent<AudioSource>();
        moveAction = InputSystem.actions.FindAction(actionSet);
    }

    private void FixedUpdate()
    {
        if (slowTimer > 0f)
        {
            slowTimer -= Time.fixedDeltaTime;

            if (slowTimer <= 0f)
            {
                speedMultiplier = 1f;
            }
        }
        Vector2 input = moveAction.ReadValue<Vector2>();

        float forwardInput = input.y;
        float turnInput = input.x;

        yaw += turnInput * turnSpeed * Time.fixedDeltaTime;
        Quaternion targetRotation = Quaternion.Euler(0f, yaw, 0f);
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 0.8f));

        Vector3 forward = transform.forward * forwardInput * moveSpeed * speedMultiplier * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forward);

        rb.angularVelocity = Vector3.zero;
    }

    public void SetSpeedMultiplier(float value)
    {
        speedMultiplier = value;
    }

    public void ModifySpeed(float multiplier, float duration)
    {
        speedMultiplier = multiplier;
        slowTimer = duration;
    }

    void Update()
    {
        UpdateEngineSound();
    }

    void UpdateEngineSound()
    {
        float currentSpeed = rb.linearVelocity.magnitude; 
        float speedPercentage = currentSpeed / 20f; 

        engineSource.pitch = Mathf.Lerp(minPitch, maxPitch, speedPercentage);
    }
}