using UnityEngine;

public class Flashlight : MonoBehaviour, IInteractable
{
    [SerializeField] Light _lightVisual;

    public void Interact(PlayerController playerController) {
        playerController.SetFlashlight(this);
    }

    public void ToggleLight() {
        _lightVisual.enabled = !_lightVisual.enabled;
    }
}
