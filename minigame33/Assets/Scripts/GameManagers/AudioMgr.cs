using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : MonoBehaviour {
    public static AudioMgr _instance;
    public AudioSource audioSource;
    public AudioClip mainBgm;
    public AudioClip huntBgm;
    public AudioClip storyBgm;
    private void Awake()
    {
        _instance = this;
    }

    public void Play(AudioClip audioClip,bool isLoop = false) {
        if (audioSource.clip == audioClip)
        {
            return;
        }
        audioSource.clip = audioClip;
        audioSource.loop = isLoop;
        audioSource.Play();
    }
}
