using UnityEngine;
using UnityEngine.UI;

namespace AR_Assessment.Ui
{
    public class AnimationSeekbarUi : MonoBehaviour
    {
        [SerializeField] private Animation animationComponent;
        [SerializeField] private Slider slider;

        void Start()
        {
            if (slider != null)
            {
                slider.interactable = false;
                slider.minValue = 0f;
                slider.maxValue = 1f;
            }
        }

        void Update()
        {
            if (animationComponent == null || slider == null) return;

            AnimationState currentState = GetCurrentState();
            if (currentState == null || currentState.length <= 0f) return;

            float progress = 0f;

            switch (currentState.wrapMode)
            {
                case WrapMode.Loop:
                case WrapMode.Default:
                    progress = currentState.time / currentState.length;
                    progress = Mathf.Repeat(progress, 1f);
                    break;

                case WrapMode.PingPong:
                    progress = Mathf.PingPong(currentState.time, currentState.length) / currentState.length;
                    break;

                case WrapMode.Once:
                case WrapMode.ClampForever:
                default:
                    progress = Mathf.Clamp01(currentState.time / currentState.length);
                    break;
            }

            slider.SetValueWithoutNotify(progress);
        }
        AnimationState GetCurrentState()
        {
            foreach (AnimationState state in animationComponent)
            {
                if (animationComponent.IsPlaying(state.name))
                    return state;
            }

            foreach (AnimationState state in animationComponent)
            {
                return state;
            }

            return null;
        }
    }
}