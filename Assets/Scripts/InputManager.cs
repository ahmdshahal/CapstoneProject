using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFootActions;
    private PlayerController playerController;
    
    void Awake()
    {
        playerInput = new PlayerInput();
        onFootActions = playerInput.OnFoot;

        playerController = GetComponent<PlayerController>();

        onFootActions.Jump.performed += ctx => playerController.Jump();
        onFootActions.Sprint.performed += ctx => playerController.Sprint();
    }

    void FixedUpdate()
    {
        //Tell the PlayerController.cs to move using the value from our movement action
        playerController.Movement(onFootActions.Movement.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFootActions.Enable();
    }

    private void OnDisable()
    {
        onFootActions.Disable();
    }
}
