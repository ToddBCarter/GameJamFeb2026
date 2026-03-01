using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour //commented out because its causing compile issues
{
    /*
    //private PlayerInput PlayerInput; 
    private PlayerControllerNEW PlayerController;
    
    void Start() //can i change this to Start()
    {
        //PlayerInput = GetComponent<PlayerInput>();
        var players = FindObjectOfType<PlayerControllerNEW>();
        int index = PlayerInput.playerIndex;
        PlayerController = players.FirstOrDefault(m -> m.GetPlayerIndex() == index);
    }

    public void OnMove(CallbackContext context)
    {
        //PlayerInput.SetInputVector(context.ReadValue<Vector2>());
    }
    */
}
