using System;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] CinemachineCamera _fpsCamera;
    private InputHandler _inputHandler;

    private Vector2 _lookVector;
    private CinemachinePanTilt _panTilt;

    private void Start() {
        _inputHandler = InputHandler.Instance;
        _inputHandler.OnLook += InputHandler_OnLook;

        _panTilt = _fpsCamera.GetComponent<CinemachinePanTilt>();
    }

    private void InputHandler_OnLook(Vector2 vector) {
        _lookVector = vector;
    }

    private void Update() {
        transform.localEulerAngles = new Vector3(0f, _panTilt.PanAxis.Value, 0f);
    }
}
