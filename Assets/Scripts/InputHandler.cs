using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance {  get; private set; }

    public Action<Vector2> OnMove;
    public Action<Vector2> OnLook;
    public Action<bool> OnSprint;

    private InputSystem_Actions _inputAction;


    private void Awake() {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;

        _inputAction = new InputSystem_Actions();
        _inputAction.Enable();
    }

    private void Start() {
        _inputAction.Player.Move.performed += Move_performed;
        _inputAction.Player.Move.canceled += Move_canceled;
        _inputAction.Player.Look.performed += Look_performed;
        _inputAction.Player.Look.canceled += Look_canceled;
        _inputAction.Player.Sprint.performed += Sprint_performed;
        _inputAction.Player.Sprint.canceled += Sprint_canceled;
    }

    private void Sprint_performed(InputAction.CallbackContext context) {
        OnSprint?.Invoke(true);
    }
    private void Sprint_canceled(InputAction.CallbackContext context) {
        OnSprint?.Invoke(false);
    }
    private void Look_performed(InputAction.CallbackContext context) {
        var lookInput = context.ReadValue<Vector2>();
        OnLook?.Invoke(lookInput);
    }
    private void Look_canceled(InputAction.CallbackContext context) {
        OnLook?.Invoke(Vector2.zero);
    }
    private void Move_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        var moveInput = obj.ReadValue<Vector2>();
        OnMove?.Invoke(moveInput);
    }
    private void Move_canceled(InputAction.CallbackContext context) {
        OnMove?.Invoke(Vector2.zero);
    }
}
