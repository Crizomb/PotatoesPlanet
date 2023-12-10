using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public AudioSource audioSource;
    public AudioSource audioSourceBackGround;

    // Define AudioClips for different sound effects
    public AudioClip backgroundSound;
    public AudioClip killSound;
    public AudioClip deathSound;
    public AudioClip startSound;
    public AudioClip shootSound;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);


    }

    // Method to play background music
    public void PlayBackgroundMusic()
    {
        audioSourceBackGround.clip = backgroundSound;
        audioSourceBackGround.loop = true; // Looping the background music
        audioSourceBackGround.Play();
    }

    // Methods for playing specific sounds
    public void PlayKillSound()
    {
        audioSource.PlayOneShot(killSound);
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathSound);
    }

    public void PlayStartSound()
    {
        audioSource.PlayOneShot(startSound);
    }

    public void PlayShootSound()
    {
        audioSource.PlayOneShot(shootSound);
    }

    // ... other methods like StopSound(), SetVolume(), etc.
}