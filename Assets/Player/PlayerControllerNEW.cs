using UnityEngine;

public class PlayerControllerNEW : MonoBehaviour
{
    private CharacterController CharacterController;
    //private PlayerControls controls;

    [SerializeField] public float speed = 10.0f;
    [SerializeField] public float turnSpeed = 5.0f;
    [SerializeField] int playerIndex = 0;

    private float rotationY;

    private Vector3 moveDirection = Vector3.zero;
    private Vector2 inputVector = Vector2.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        CharacterController.Move(moveDirection * Time.deltaTime);
    }

    public void SetInputVector(Vector2 direction)
    {
        inputVector = direction;
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }
}
