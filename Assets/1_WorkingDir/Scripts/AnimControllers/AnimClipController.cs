using UnityEngine;
namespace AR_Assessment.AnimControllers
{
    public class AnimClipController : MonoBehaviour
    {
        public Animation glbModelAnimationComponent;
        public string currentAnimClipName;

        void Start()
        {
            glbModelAnimationComponent.Play("Meditate");
            currentAnimClipName = "Meditate";
            glbModelAnimationComponent.wrapMode = WrapMode.Loop;
        }

        public void SetAnimationClip(int index)
        {
            switch(index)
            {
                case 0:
                    glbModelAnimationComponent.Play("Meditate");
                    currentAnimClipName = "Meditate";
                    break;

                case 1:
                    glbModelAnimationComponent.Play("Pushup");
                    currentAnimClipName = "Pushup";
                    break;

                case 2:
                    glbModelAnimationComponent.Play("Yes");
                    currentAnimClipName = "Yes";
                    break;

                default:
                    Debug.Log("No State Found");
                    break;
            }
        }
    }
}