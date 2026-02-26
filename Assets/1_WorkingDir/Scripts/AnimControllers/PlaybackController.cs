using UnityEngine;
namespace AR_Assessment.AnimControllers
{
    public class PlaybackController : MonoBehaviour
    {
        public Animation glbModelAnimationComponent;
        public AnimClipController animClipController;
        public PlaybackSpeedController playbackSpeedController;

        void PlayAnim() { glbModelAnimationComponent.Play(animClipController.currentAnimClipName); }
        void StopAnim() { glbModelAnimationComponent.Stop(); }

        bool isPlaying = true;
        public void TogglePlayback()
        {
            isPlaying = !isPlaying;
            if (isPlaying == true) PlayAnim(); if(isPlaying == false) StopAnim();
        }

        string GetCurrentClipName()
        {
            foreach (AnimationState state in glbModelAnimationComponent)
            {
                if (glbModelAnimationComponent.IsPlaying(state.name))
                {
                    return state.name;
                }
            }

            return null;
        }

        public void ForwardPlayBack()
        {
            AnimationState state = glbModelAnimationComponent[GetCurrentClipName()];
            if (state == null) return;

            state.speed = Mathf.Abs(playbackSpeedController.newSpeed);
            glbModelAnimationComponent.Play(state.name);
        }

        public void ReversePlayback()
        {
            AnimationState state = glbModelAnimationComponent[GetCurrentClipName()];
            if (state == null) return;

            state.speed = -Mathf.Abs(playbackSpeedController.newSpeed);

            if (!glbModelAnimationComponent.IsPlaying(state.name))
                state.time = state.length;

            glbModelAnimationComponent.Play(state.name);
        }
    }
}