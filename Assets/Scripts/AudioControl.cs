using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    [SerializeField] AudioClip fire;
    [SerializeField] AudioClip explosion;
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayFireSound()
    {
        audio.PlayOneShot(fire);
    }
    public void PlayExplosion()
    {
        audio.PlayOneShot(explosion);
    }
}
