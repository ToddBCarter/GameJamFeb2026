using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController CharacterController;
    //private PlayerControls controls;

    [SerializeField] public float speed = 10.0f;
    [SerializeField] public float turnSpeed = 5.0f;

    private float rotationY;

    //private Vector2 moveInput;
    //private Vector2 turnInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
    }

    public void Move(Vector2 movementVector)
    {
        Vector2 move = transform.forward * movementVector.y + transform.right * movementVector.x;
        move = move * speed * Time.deltaTime;
        CharacterController.Move(move);

        //turning
        rotationY += movementVector.x * turnSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, rotationY, 0);
    }

    /*public void Turn(Vector2 turnVector)
    {
        rotationY += turnVector.x * turnSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, rotationY, 0);
    }*/
}

/* 
old move functions

    public void Move(Vector2 movementVector)
    {
        Vector2 move = transform.forward * movementVector.y + transform.right * movementVector.x;
        move = move * speed * Time.deltaTime;
        CharacterController.Move(move);
    }

*/