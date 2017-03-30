using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundObject : MonoBehaviour
{
    [SerializeField]
    private AudioClip soundClip;

    private void Start()
    {
        InvokeRepeating("PlaySound", Random.Range(5f, 8f), Random.Range(4f, 10f));
    }

    void PlaySound()
    {
        AudioSource.PlayClipAtPoint(soundClip, this.transform.position);

    }

}