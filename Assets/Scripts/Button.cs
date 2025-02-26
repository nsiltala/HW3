using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour 
{
    private bool isMusicPlaying = false;
    public AudioSource source;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nappi"))
        {
            ToggleMusic();
        }
    }

    private void ToggleMusic()
    {
        if (isMusicPlaying)
        {
            // Stop the music
            source.Stop();
            isMusicPlaying = false;
            Debug.Log("Music stopped.");
        }
        else
        {
            // Play the music
            source.Play();
            isMusicPlaying = true;
            Debug.Log("Music started.");
        }
    }
}