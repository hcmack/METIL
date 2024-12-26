using UnityEngine;

public class ButtonEventHandler : MonoBehaviour
{
    public AudioSource audioSource; // Drag your AudioSource here
    public AudioClip audioClip;     // Drag your AudioClip here

    // Method to play audio when triggered
    public void PlayAudio()
    {
        if (audioSource != null && audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
            Debug.Log("Audio played on button press!");
        }
        else
        {
            Debug.LogError("AudioSource or AudioClip is not assigned.");
        }
    }

    // Custom "Start" event
    public void StartEvent()
    {
        Debug.Log("Start event triggered!");
        // Add any custom logic here
       
    }
}