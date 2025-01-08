using UnityEngine;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject background; // Reference to Background object
    public GameObject audioManager; // Reference to AudioManager object

    private void Awake()
    {
        // Singleton Pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Mark Background and AudioManager as persistent
        if (background != null)
        {
            DontDestroyOnLoad(background);
        }

        if (audioManager != null)
        {
            DontDestroyOnLoad(audioManager);
        }
    }

    public void InitializePersistentObjects()
    {
        Debug.Log("Initializing persistent objects...");

        // Reset Background Video
        if (background != null)
        {
            var videoPlayer = background.GetComponent<VideoPlayer>();
            if (videoPlayer != null)
            {
                videoPlayer.targetCamera = Camera.main; // Reconnect camera
                videoPlayer.Stop(); // Ensure video restarts
                videoPlayer.Play();
                Debug.Log("Background video restarted.");
            }
        }

        // Reset Music and SFX
        if (audioManager != null)
        {
            var music = audioManager.transform.Find("Music")?.GetComponent<AudioSource>();
            if (music != null)
            {
                music.Stop(); // Ensure music restarts
                music.Play();
                Debug.Log("Music restarted.");
            }

            var sfx = audioManager.transform.Find("SFX")?.GetComponent<AudioSource>();
            if (sfx != null)
            {
                sfx.Stop(); // Ensure SFX restarts
                sfx.Play();
                Debug.Log("SFX restarted.");
            }
        }
    }
}
