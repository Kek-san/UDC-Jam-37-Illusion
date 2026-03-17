using UnityEngine;

public class Flashlight : MonoBehaviour, IInteractable
{
    [SerializeField] Light _lightVisual;
    [SerializeField] Controller_VFX_Material _material;

    public void Interact(PlayerController playerController) {
        playerController.SetFlashlight(this);
    }

    public void ToggleLight() {
        _lightVisual.enabled = !_lightVisual.enabled;
        _material.Enable = !_material.Enable;
    }
}
