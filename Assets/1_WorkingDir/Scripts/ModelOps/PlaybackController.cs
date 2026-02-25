using UnityEngine;
using System.Collections;

public class PlaybackController : MonoBehaviour
{
    public Animator glbModelAnimatorComponent;

    void PlayAnim() { glbModelAnimatorComponent.StartPlayback(); }
    void StopAnim() { glbModelAnimatorComponent.StopPlayback(); }

    bool isPlaying = true;
    public void TogglePlayback()
    {
        isPlaying = !isPlaying;
        if (isPlaying) StopAnim(); else PlayAnim();
    }
    public void ForwardPlayBack()
    {
        if (glbModelAnimatorComponent != null)
        {
            StartCoroutine(PlayAnimationRuntime(true));
        }
    }

    public void ReversePlayback()
    {
        if (glbModelAnimatorComponent != null)
        {
            StartCoroutine(PlayAnimationRuntime(false));
        }
    }
    private IEnumerator PlayAnimationRuntime(bool forward)
    {
        if (glbModelAnimatorComponent == null) yield break;

        AnimatorClipInfo[] clips = glbModelAnimatorComponent.GetCurrentAnimatorClipInfo(0);
        if (clips.Length == 0) yield break;

        float clipLength = clips[0].clip.length;
        string clipName = clips[0].clip.name;

        float normalizedTime = forward ? 0f : 1f;

        while (forward ? normalizedTime < 1f : normalizedTime > 0f)
        {
            glbModelAnimatorComponent.Play(clipName, 0, normalizedTime);
            glbModelAnimatorComponent.Update(0f);

            normalizedTime += (forward ? 1 : -1) * (Time.deltaTime / clipLength);
            yield return null;
        }

        glbModelAnimatorComponent.Play(clipName, 0, forward ? 1f : 0f);
        glbModelAnimatorComponent.Update(0f);
    }
}