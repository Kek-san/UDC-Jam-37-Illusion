using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 10f;
    [SerializeField] float _interactRange = 5f;
    [SerializeField] LayerMask _interactLayer;
    [SerializeField] Transform _flashLightLocation;

    private Flashlight _flashLight;
    private IInteractable _interactable;


    private Vector2 _moveVector = Vector2.zero;
    private bool _isSprinting = false;
    private InputHandler _inputHandler;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _inputHandler = InputHandler.Instance;
        _inputHandler.OnMove += InputHandler_OnMove;
        _inputHandler.OnSprint += InputHandler_OnSprint;
        _inputHandler.OnAttack += InputHandler_OnAttack;
        _inputHandler.OnInteract += InputHandler_OnInteract;
    }

    private void InputHandler_OnSprint(bool obj) {
        _isSprinting = obj;
    }
    private void InputHandler_OnMove(Vector2 vector) {
        _moveVector = vector;
    }
    private void InputHandler_OnInteract() {
        if (_interactable == null) return;
        _interactable.Interact(this);
    }

    private void InputHandler_OnAttack() {
        if (_flashLight != null) {
            _flashLight.ToggleLight();
        }
    }

    private void Update() {
        Movement();
        bool hasInteractable = Physics.Raycast(Camera.main.transform.position, 
                                               Camera.main.transform.forward, 
                                               out RaycastHit hitInfo, 
                                               _interactRange, 
                                               _interactLayer);

        if (hasInteractable)
        {

            _interactable = hitInfo.transform.GetComponent<IInteractable>();
            if (_interactable == null) return;
        }


    }

    private void OnDrawGizmos() {
        Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * _interactRange);
    }
    private void Movement() {
        Vector2 moveInput = _moveVector;

        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.y);

        moveDir = transform.right * moveDir.x + transform.forward * moveDir.z;

        float dotProduct = Vector3.Dot(transform.forward, moveDir);
        if (_isSprinting && dotProduct > 0) {
            float sprintSpeed = _moveSpeed * 1.15f;
            transform.position += moveDir * sprintSpeed * Time.deltaTime;

        }
        transform.position += moveDir * _moveSpeed * Time.deltaTime;
    }

    public void SetFlashlight(Flashlight flashlight) {
        _flashLight = flashlight;
        _flashLight.GetComponent<BoxCollider>().enabled = false;
        _flashLight.transform.parent = _flashLightLocation;
        _flashLight.transform.localPosition = Vector3.zero;
        _flashLight.transform.localEulerAngles = Vector3.zero;
    }

    public void ClearFlashlight() {
        _flashLight = null;
    }

    public Flashlight GetFlashlight() {
        return _flashLight;
    }
}
