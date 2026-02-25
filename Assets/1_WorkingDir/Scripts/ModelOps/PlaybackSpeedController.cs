using UnityEngine;

public class PlaybackSpeedController : MonoBehaviour
{
    public Animator glbModelAnimatorComponent;

    public void ControlSpeed(int indexValue)
    {
        if (glbModelAnimatorComponent == null)
        {
            Debug.LogWarning("Animator component is not assigned!");
            return;
        }

        switch (indexValue)
        {
            case 0:
                glbModelAnimatorComponent.speed = 1f; 
                break;
            case 1:
                glbModelAnimatorComponent.speed = 0.5f;   
                break;
            case 2:
                glbModelAnimatorComponent.speed = 2f;   
                break;
            case 3:
                glbModelAnimatorComponent.speed = 5f;   
                break;
            default:
                glbModelAnimatorComponent.speed = 1f;  
                break;
        }
    }
}