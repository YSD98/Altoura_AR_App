using UnityEngine;
namespace AR_Assessment.AnimControllers
{
    public class PlaybackSpeedController : MonoBehaviour
    {
        public Animation glbModelAnimationComponent;
        public float newSpeed = 1f;

        public void ControlSpeed(int indexValue)
        {
            if (glbModelAnimationComponent == null)
            {
                Debug.LogWarning("Animation component is not assigned!");
                return;
            }

            switch (indexValue)
            {
                case 0:
                    newSpeed = 1f;
                    break;
                case 1:
                    newSpeed = 0.5f;
                    break;
                case 2:
                    newSpeed = 2f;
                    break;
                case 3:
                    newSpeed = 5f;
                    break;
                default:
                    newSpeed = 1f;
                    break;
            }
            foreach (AnimationState state in glbModelAnimationComponent)
            {
                state.speed = newSpeed;
            }
        }
    }
}