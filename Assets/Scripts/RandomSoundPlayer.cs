using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class RandomSoundPlayer : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips;

    private AudioSource audioSource;
    void Start()
    {
       audioSource = GetComponent<AudioSource>(); 
    }

    public void PlayRandomSound()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Count - 1)];
        audioSource.Play();
    }
}
