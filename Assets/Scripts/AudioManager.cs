using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    private static AudioManager _instance;

    public static AudioManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);

            return;
        }

        _instance = this;
        DontDestroyOnLoad(this);
    }

    public void PlayOnShot(AudioClip audioClip)
    {
        if (audioClip)
        {
            Debug.Log("gogo");
            audioSource.PlayOneShot(audioClip);
        }
    }
}
