using UnityEngine;

public class AnimClipController : MonoBehaviour
{
    public Animator glbModelAnimatorComponent;
    public void SetAnimationClip(int index)
    {
        switch(index)
        {
            case 0:
                glbModelAnimatorComponent.Play("Meditate");
                break;
            case 1:
                glbModelAnimatorComponent.Play("Pushup");
                break;
            case 2:
                glbModelAnimatorComponent.Play("Yes");
                break;
            default:
                Debug.Log("No State FOund");
                break;
        }
    }
}