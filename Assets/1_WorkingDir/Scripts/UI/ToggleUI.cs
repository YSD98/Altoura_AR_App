using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ToggleUI : MonoBehaviour
{
    public XRGrabInteractable xRGrabInteractable;
    public void DisableUiObject(GameObject UiGameObject)
    {
        UiGameObject.SetActive(false);
    }
    public void EnableUiObject(GameObject UiGameObject)
    {
        UiGameObject.SetActive(true);
    }
}
