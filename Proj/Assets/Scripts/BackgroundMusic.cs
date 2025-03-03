using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip backgroundMusic; 
    private AudioSource audioSource;
    public float fadeInDuration = 3f;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.playOnAwake = false; 
        audioSource.volume = 0f; 
        audioSource.Play();
        StartCoroutine(FadeInMusic());
    }

    IEnumerator FadeInMusic()
    {
        float elapsedTime = 0f;
        float targetVolume = 0.5f;

        while (elapsedTime < fadeInDuration)
        {
            audioSource.volume = Mathf.Lerp(0f, targetVolume, elapsedTime / fadeInDuration);
            elapsedTime += Time.deltaTime;
            yield return null; 
        }

        audioSource.volume = targetVolume; 
    }

}
