using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Controller_VFX_Material : MonoBehaviour
{
    const string PLANE_POSITION = "_PlanePosition";
    const string PLANE_FORWARD = "_PlaneForward";
    const string ENABLED = "_Enabled";

    [SerializeField] Transform _plane;
    [SerializeField] List<Material> _materialList;
    public bool Enable;

    private void Update() {
        Vector3 planePosition = _plane.position;
        Vector3 planeForward = _plane.forward;

        foreach(Material mat in _materialList) {
            mat.SetVector(PLANE_POSITION, planePosition);
            mat.SetVector(PLANE_FORWARD, planeForward);
            mat.SetFloat(ENABLED, Enable ? 1f : 0f);
        }

    }
}
