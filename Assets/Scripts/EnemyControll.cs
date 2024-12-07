using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D enemy;
    public float moveSpeed = 3f;
    public float shootInterval = 2f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint; 

    private float shootTimer; 
    public bool changeDirection = false;

    void Start()
    {
      
        enemy = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
      
        MoveEnemy();

      
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    public void MoveEnemy()
    {
   
        if (changeDirection)
        {
            enemy.linearVelocity = new Vector2(-1, 0) * moveSpeed;
        }
        else
        {
            enemy.linearVelocity = new Vector2(1, 0) * moveSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.name == "RightWall")
        {
            Debug.Log("Right wall hit");
            changeDirection = true;
        }
        else if (col.gameObject.name == "LeftWall")
        {
            Debug.Log("Left wall hit");
            changeDirection = false;
        }
    }

    void Shoot()
    {

        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
        else
        {
            //Debug.LogError("BulletPrefab vagy BulletSpawnPoint nincs beallitva!");
        }
    }
}
