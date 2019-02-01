using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundsEffects : MonoBehaviour
{

    public static SoundsEffects Instance;

    private AudioSource Source;
    public AudioClip typingSound;
    public AudioClip AmbientSound;
    public AudioClip DecorSound;



    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffectsHelper!");
        }
        Instance = this;
    }

    private void Start()
    {
        Source = GetComponent<AudioSource>();
        MakeAmbientSound();
    }

    public void MakeTypingSound()
    {
        AudioSource.PlayClipAtPoint(typingSound, transform.position);
    }

    public void MakeAmbientSound()
    {
        Source.clip = AmbientSound;
        Source.Play(0);
    }

    public void MakeDecorSound()
    {
        AudioSource.PlayClipAtPoint(DecorSound, transform.position);
    }

    public void Stop()
    {
        Stop(Source);
    }

    /// <summary>
    /// Lance la lecture d'un son
    /// </summary>
    /// <param name="originalClip"></param>


    private void Stop(AudioSource originalClip)
    {
        originalClip.Stop();

    }
}
