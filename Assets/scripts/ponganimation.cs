using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ponganimation : MonoBehaviour
{
    public bool pressed;
    
    public UnityEngine.Video.VideoClip videoClip;

    void Start()
    {
        var videoPlayer = gameObject.AddComponent<UnityEngine.Video.VideoPlayer>();
        var audioSource = gameObject.AddComponent<AudioSource>();

        videoPlayer.playOnAwake = false;
        videoPlayer.clip = videoClip;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.MaterialOverride;
        videoPlayer.targetMaterialRenderer = GetComponent<Renderer>();
        videoPlayer.targetMaterialProperty = "_MainTex";
        videoPlayer.audioOutputMode = UnityEngine.Video.VideoAudioOutputMode.AudioSource;
        videoPlayer.SetTargetAudioSource(0, audioSource);
    }

    void Update()
    {
        if (pressed == true)
        {
            var vp = GetComponent<UnityEngine.Video.VideoPlayer>();

            if (vp.isPlaying)
            {
                vp.Pause();
            }
            else
            {
                vp.Play();
                Debug.Log("played");
            }
        }
    }
}
