using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] Light _lightVisual;


    public void ToggleLight() {
        _lightVisual.enabled = !_lightVisual.enabled;
    }
}
