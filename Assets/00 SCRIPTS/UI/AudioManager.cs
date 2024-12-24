using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    protected static AudioManager instance;
    public static AudioManager Instance => instance;

    public AudioSource AudioSource;
    public AudioSource vfx;

    public AudioClip bgClip;
    public AudioClip slashClip;
    public AudioClip fireClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        AudioSource.clip = bgClip;
        AudioSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        vfx.PlayOneShot(clip);
    }
}
