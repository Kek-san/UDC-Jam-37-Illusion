using System;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private InputHandler _inputHandler;

    private Vector2 _lookVector;

    private void Start() {
        _inputHandler = InputHandler.Instance;
        _inputHandler.OnLook += InputHandler_OnLook;
    }

    private void InputHandler_OnLook(Vector2 vector) {
        _lookVector = vector;
    }

    private void Update() {
        
    }
}
