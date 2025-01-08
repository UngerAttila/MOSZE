using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 3f;
    public GameObject bulletSpawn;

    private AudioManager audioManager;

    void Awake()
    {
        // Find the AudioManager in the scene
        GameObject audioManagerObject = GameObject.FindGameObjectWithTag("AudioManager");
        if (audioManagerObject != null)
        {
            audioManager = audioManagerObject.GetComponent<AudioManager>();
        }
        else
        {
            Debug.LogWarning("AudioManager GameObject not found!");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Check if the bullet hits an enemy or a clone
        if (col.gameObject.name == "Enemy" || col.gameObject.name == "Enemy 1(Clone)")
        {
            // Play hit sound
            if (audioManager != null)
            {
                audioManager.PlaySFX(audioManager.hit);
            }
            else
            {
                Debug.LogWarning("AudioManager is not assigned!");
            }

            // Deactivate the enemy
            col.gameObject.SetActive(false);

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
