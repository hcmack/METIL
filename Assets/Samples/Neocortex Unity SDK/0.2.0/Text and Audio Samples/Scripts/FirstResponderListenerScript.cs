
using UnityEngine;
using Neocortex.Data;
public class FirstResponderListenerScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;  // Reference to an AudioSource to play the audio clip
    [SerializeField] private AudioClip rescueAudioClip; // The prewritten audio clip to play when "RESCUE" is triggered
    [SerializeField] private AudioClip startAudioClip;  // The audio clip to play for the "START" event
    [SerializeField] private AudioClip radioactiveAudioClip; // The audio clip to play for the "RADIOACTIVE" event
    [SerializeField] private AudioClip extinguishAudioClip; // The audio clip to play for the "EXTINGUISH" event

    private void OnEnable()
    {
        // Subscribe to events when the script is enabled
        EventManager.StartListening("START", HandleStart);
        EventManager.StartListening("RADIOACTIVE", HandleRadioactive);
        EventManager.StartListening("RESCUE", HandleRescue);
        EventManager.StartListening("EXTINGUISH", HandleExtinguish);

        Debug.Log("ListenerScript subscribed to events.");
    }

    private void OnDisable()
    {
        // Unsubscribe from events to avoid memory leaks when the script is disabled
        EventManager.StopListening("START", HandleStart);
        EventManager.StopListening("RADIOACTIVE", HandleRadioactive);
        EventManager.StopListening("RESCUE", HandleRescue);
        EventManager.StopListening("EXTINGUISH", HandleExtinguish);

        Debug.Log("ListenerScript unsubscribed from events.");
    }

    // Handle the "START" event
    private void HandleStart()
    {
        Debug.Log("START event triggered.");

        if (audioSource != null && startAudioClip != null)
        {
            audioSource.clip = startAudioClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource or Start AudioClip is not assigned.");
        }
    }

    // Handle the "RADIOACTIVE" event
    private void HandleRadioactive()
    {
        Debug.Log("RADIOACTIVE event triggered.");

        if (audioSource != null && radioactiveAudioClip != null)
        {
            audioSource.clip = radioactiveAudioClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource or Radioactive AudioClip is not assigned.");
        }
    }

    // Handle the "RESCUE" event
    private void HandleRescue()
    {
        Debug.Log("RESCUE event triggered.");

        if (audioSource != null && rescueAudioClip != null)
        {
            audioSource.clip = rescueAudioClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource or Rescue AudioClip is not assigned.");
        }
    }

    // Handle the "EXTINGUISH" event
    private void HandleExtinguish()
    {
        Debug.Log("EXTINGUISH event triggered.");

        if (audioSource != null && extinguishAudioClip != null)
        {
            audioSource.clip = extinguishAudioClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource or Extinguish AudioClip is not assigned.");
        }
    }
}
