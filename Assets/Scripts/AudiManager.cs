using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource; // Background music source
    [SerializeField] AudioSource SFXSource;  // Sound effects source

    public AudioClip backround;
    public AudioClip shoot;
    public AudioClip hit;
    public AudioClip gameover;

    private static AudioManager instance;

    private void Awake()
    {
        // Ensure only one instance of AudioManager exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instances
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Persist across scenes
    }

    private void Start()
    {
        if (musicSource != null && backround != null)
        {
            musicSource.clip = backround;
            musicSource.loop = true; // Loop background music
            musicSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        // Play the clip passed to the function
        if (SFXSource != null && clip != null)
        {
            SFXSource.PlayOneShot(clip);
        }
    }
}
