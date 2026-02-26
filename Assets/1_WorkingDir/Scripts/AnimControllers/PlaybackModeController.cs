using UnityEngine;

namespace AR_Assessment.AnimControllers
{
    public class PlaybackModeController : MonoBehaviour
    {
        public Animation glbModelAnimationComponent;
        public AnimClipController animClipController;
        public void LoopPlay()
        {
            glbModelAnimationComponent.wrapMode = WrapMode.Loop;
            glbModelAnimationComponent.Play(animClipController.currentAnimClipName);
        }

        public void OncePlay()
        {
            glbModelAnimationComponent.Stop();
            glbModelAnimationComponent.wrapMode = WrapMode.Once;
            glbModelAnimationComponent.Play(animClipController.currentAnimClipName);
        }

        public void PingPongPlay()
        {

            glbModelAnimationComponent.wrapMode = WrapMode.PingPong;
            glbModelAnimationComponent.Play(animClipController.currentAnimClipName);
        }
    }
}