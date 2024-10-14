using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioMusic, audioEffect;
    public AudioClip jumpsound, sizeupSound, fireball, coin, diesound, StartMusic, PlayGameMusic;
    public static AudioManager instance;

    public bool Mute;
    private void Awake()
    {
        instance = this;
    }
    public void PlaySound(AudioClip audioclip)
    {
        audioEffect.PlayOneShot(audioclip);
    }
    public void PlayMusic(AudioClip audioClip)
    {
        audioMusic.clip = audioClip;
        audioMusic.Play();
        
    }
    public void MuteSound()
    {
        Mute = !Mute;
        audioMusic.mute = Mute;
        audioEffect.mute = Mute;
    }
}
