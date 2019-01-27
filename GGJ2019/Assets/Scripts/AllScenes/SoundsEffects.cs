using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsEffects : MonoBehaviour
{

    /// <summary>
    /// Singleton
    /// </summary>
    public static SoundsEffects Instance;

    public AudioClip typingSound;
    public AudioClip fire;


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
        MakeFireSound();
    }

    public void MakeTypingSound()
    {
        MakeSound(typingSound);
    }

    public void MakeFireSound()
    {
        MakeSound(fire);
    }

    /// <summary>
    /// Lance la lecture d'un son
    /// </summary>
    /// <param name="originalClip"></param>
    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
