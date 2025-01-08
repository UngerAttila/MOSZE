using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 3f;

    public Transform bulletSpawn;
    public GameObject bullet;

    public float fireRate = 1.0f;
    private float nextFire = 0.0f;

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
            Debug.LogWarning("AudioManager not found! Sound effects will not play.");
        }
    }

    void Start()
    {
        if (bulletSpawn == null)
        {
            bulletSpawn = this.gameObject.transform;
        }
    }

    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            // Instantiate the bullet
            GameObject spawnedBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);

            // Apply velocity to the bullet
            Rigidbody2D rb = spawnedBullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = bulletSpawn.up * speed;
            }

            // Play the "shoot" sound effect
            if (audioManager != null)
            {
                audioManager.PlaySFX(audioManager.shoot);
            }
            else
            {
                Debug.LogWarning("AudioManager reference is missing!");
            }

            // Destroy the bullet after its lifetime
            Destroy(spawnedBullet, lifetime);
        }
    }
}

