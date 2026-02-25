using UnityEngine;
using System.Collections;

public class PlaybackModeController : MonoBehaviour
{
    public Animator glbModelAnimatorComponent;

    private Coroutine pingPongCoroutine;

    public enum PlaybackMode { Once, Loop, PingPong }

    // Play the currently active clip once
    public void SetPlayModeTo_Once()
    {
        StopPingPong();

        AnimatorClipInfo[] clipInfo = glbModelAnimatorComponent.GetCurrentAnimatorClipInfo(0);
        if (clipInfo.Length > 0)
        {
            AnimationClip currentClip = clipInfo[0].clip;
            glbModelAnimatorComponent.speed = 1f;
            glbModelAnimatorComponent.Play(currentClip.name, 0, 0f);
        }
    }

    // Play the currently active clip in loop
    public void SetPlayModeTo_Loop()
    {
        StopPingPong();

        AnimatorClipInfo[] clipInfo = glbModelAnimatorComponent.GetCurrentAnimatorClipInfo(0);
        if (clipInfo.Length > 0)
        {
            AnimationClip currentClip = clipInfo[0].clip;
            glbModelAnimatorComponent.speed = 1f;
            glbModelAnimatorComponent.Play(currentClip.name, 0, 0f);
            // Looping is controlled in the Animator Controller (Loop Time)
        }
    }

    // Play the currently active clip in ping-pong
    public void SetPlayModeTo_PingPong()
    {
        StopPingPong();

        AnimatorClipInfo[] clipInfo = glbModelAnimatorComponent.GetCurrentAnimatorClipInfo(0);
        if (clipInfo.Length > 0)
        {
            AnimationClip currentClip = clipInfo[0].clip;
            pingPongCoroutine = StartCoroutine(PlayPingPongCoroutine(currentClip));
        }
    }

    private void StopPingPong()
    {
        if (pingPongCoroutine != null)
        {
            StopCoroutine(pingPongCoroutine);
            pingPongCoroutine = null;
        }
        glbModelAnimatorComponent.speed = 1f;
    }

    private IEnumerator PlayPingPongCoroutine(AnimationClip clip)
    {
        while (true)
        {
            // Forward
            glbModelAnimatorComponent.speed = 1f;
            glbModelAnimatorComponent.Play(clip.name, 0, 0f);
            yield return new WaitForSeconds(clip.length);

            // Backward
            glbModelAnimatorComponent.speed = -1f;
            glbModelAnimatorComponent.Play(clip.name, 0, 1f);
            yield return new WaitForSeconds(clip.length);
        }
    }
}