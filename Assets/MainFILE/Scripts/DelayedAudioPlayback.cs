using UnityEngine;

public class DelayedAudioPlayback : MonoBehaviour
{
    public float delaySeconds = 2f;

    public AudioSource audioSource;
    private bool hasPlayed = false;

    

    private void Update()
    {
        if (!hasPlayed)
        {
            delaySeconds -= Time.deltaTime;

            if (delaySeconds <= 0f)
            {
                PlayAudio();
                hasPlayed = true;
            }
        }
    }

    private void PlayAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}