using UnityEngine;

[ExecuteInEditMode]
public class Controller_VFX_Material : MonoBehaviour
{
    [SerializeField] Transform _plane;
    [SerializeField] Material _body, _legs, _arms;

    private void Update() {
        Vector3 planePosition = _plane.position;
        Vector3 planeForward = _plane.forward;

        _body.SetVector("_PlanePosition", planePosition);
        _body.SetVector("_PlaneForward", planeForward);
        _legs.SetVector("_PlanePosition", planePosition);
        _legs.SetVector("_PlaneForward", planeForward);
        _arms.SetVector("_PlanePosition", planePosition);
        _arms.SetVector("_PlaneForward", planeForward);
    }
}
