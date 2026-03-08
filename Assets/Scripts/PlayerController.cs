using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 10f;
    [SerializeField] float _lookSens = 0.1f;
    [SerializeField] float _upDownLookRange = 80f;

    private Vector2 _lookVector = Vector2.zero;
    private Vector2 _moveVector = Vector2.zero;
    private bool _isSprinting = false;
    private InputHandler _inputHandler;

    private void Start() {
        _inputHandler = InputHandler.Instance;
        _inputHandler.OnMove += InputHandler_OnMove;
        _inputHandler.OnLook += InputHandler_OnLook;
        _inputHandler.OnSprint += InputHandler_OnSprint;
    }

    private void InputHandler_OnSprint(bool obj) {
        _isSprinting = obj;
    }

    private void InputHandler_OnLook(Vector2 vector) {
        _lookVector = vector;
    }

    private void InputHandler_OnMove(Vector2 vector) {
        _moveVector = vector;
    }

    private void Update() {
        Vector2 moveInput = _moveVector;

        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y);

        float dotProduct = Vector3.Dot(transform.forward, moveDir);
        if (_isSprinting && dotProduct > 0) {
            float sprintSpeed = _moveSpeed * 1.15f;
            transform.position += moveDir * sprintSpeed * Time.deltaTime;

        }
        transform.position += moveDir * _moveSpeed * Time.deltaTime;


    }
}
