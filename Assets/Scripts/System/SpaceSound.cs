using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceSound : MonoBehaviour
{
    public AudioClip soundClip; // 鳴らす音の AudioClip

    private void Update()
    {
        // スペースキーを押した場合
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 音を再生
            PlaySound();
        }
    }

    private void PlaySound()
    {
        if (soundClip != null)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = soundClip;
            audioSource.volume = 0.75f;
            audioSource.Play();
        }
    }
}
