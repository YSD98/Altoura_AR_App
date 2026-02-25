using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class XRClickOrDragDetector : MonoBehaviour
{
    public float dragThreshold = 0.01f;
    private XRGrabInteractable grabInteractable;
    private Vector3 grabStartPosition;
    private bool isHeld = false;

    public UnityEvent onClicked,onDragReleased;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        grabStartPosition = transform.position;
        isHeld = true;
        // Debug.Log($"[{name}] Grabbed by {args.interactorObject.transform.name}");
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        if (!isHeld) return;

        float distanceMoved = Vector3.Distance(grabStartPosition, transform.position);

        if (distanceMoved <= dragThreshold)
        {
            OnClick(args);
        }
        else
        {
            OnDragRelease(args);
        }

        isHeld = false;
    }

    private void OnClick(SelectExitEventArgs args)
    {
        onClicked.Invoke();
    }

    private void OnDragRelease(SelectExitEventArgs args)
    {
        onDragReleased.Invoke();
    }
}