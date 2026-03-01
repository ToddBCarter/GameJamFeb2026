using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public PlayerController PlayerController;
    private InputAction moveAction;
    //private InputAction turnAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        //turnAction = InputSystem.actions.FindAction("Turn");
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementVector = moveAction.ReadValue<Vector2>();
        PlayerController.Move(movementVector);

        //Vector2 turnVector = turnAction.ReadValue<Vector2>();
        //PlayerController.Turn(turnVector);
    }
}
