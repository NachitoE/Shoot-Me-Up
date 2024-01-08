
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource audioSrc;
    public List<AudioClip> clipList = new List<AudioClip>();
    public void PlayAudioClip()
    {
        audioSrc.volume = GameDataManager.instance.GetAudioData().SFX;
        audioSrc.Play();
    }
    public void SetAudioClip(AudioClip clip)
    {
        audioSrc.clip = clip;
    }
}
