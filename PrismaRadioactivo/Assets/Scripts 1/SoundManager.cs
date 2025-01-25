using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource _AudioSource;
    public AudioClip _ThrowBubbleSound;
    public AudioClip _ZombieTransformationSound;
    public AudioClip _JumpSound;
    public AudioClip CrowdAmbience;
    public static SoundManager Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        StartMusic();
    }
    public void StartMusic() 
    {
        _AudioSource.clip = CrowdAmbience;
        _AudioSource.Play();
    }
    public void PlayThrowBubble() 
    {
        _AudioSource.PlayOneShot(_ThrowBubbleSound);
    }
    public void PlayZombieTransform()
    {
        _AudioSource.PlayOneShot(_ZombieTransformationSound);
    }
    public void PlayJumpSound()
    {
        _AudioSource.PlayOneShot(_JumpSound);
    }
}
