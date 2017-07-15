using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;
    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.Volume;
            s.source.pitch = s.Pitch;
            s.source.loop = s.Loop;
        }
    }
    private void Start()
    {
        PlaySong("MainTheme");
        FadingSongOutAndNewIn("MainTheme", "SecondSound");
    }
    public void PlaySong(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.SoundName == name);
        if (s == null)
        {
            return;
        }
        s.source.Play();
    }

    public void FadingSongOutAndNewIn(string soundToFadeOut, string soundToFadeIn)
    {
        StartCoroutine(FadeOut(soundToFadeOut, soundToFadeIn));
    }

    IEnumerator FadeOut(string soundToFadeOut,string soundToFadeIn)
    {
        Sound fadeOut = Array.Find(sounds, sound => sound.SoundName == soundToFadeOut);
        Sound fadeIn = Array.Find(sounds, sound => sound.SoundName == soundToFadeIn);
        if (fadeOut == null)
        {
            StopCoroutine("FadeOut");
            Debug.Log("Stopped FadeOut Coroutine");
        }
        if (fadeIn == null)
        {
            StopCoroutine("fadeIn");
            Debug.Log("Stopped FadeIn Coroutine");
        }

        fadeIn.source.volume = 0;
        fadeIn.source.Play();
      
        do
        {
            if (fadeOut.source.volume < 0.01f)
            {
                fadeOut.source.volume = 0;
            }
            if (fadeIn.source.volume > 0.8f)
            {
                fadeIn.source.volume = 1f;
            }
            fadeOut.source.volume -= 0.2f;
            fadeIn.source.volume += 0.2f;

            yield return new WaitForSeconds(2.5f);
        } while (fadeIn.source.volume < 0.85f);
    }
}
