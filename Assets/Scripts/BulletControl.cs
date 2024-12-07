using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 3f;

    public Transform bulletSpawn;
    public GameObject bullet;

    public float fireRate = 1.0f;
    private float nextFire = 0.0f;

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

            GameObject spawnedBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);

            Rigidbody2D rb = spawnedBullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = bulletSpawn.up * speed;
            }
            Destroy(spawnedBullet, lifetime);
        }
    }
}

