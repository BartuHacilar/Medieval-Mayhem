using UnityEngine;

public class PlayMusicWasteland : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(); // Start playing the audio clip
    }
}
