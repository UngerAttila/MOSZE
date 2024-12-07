using UnityEngine;

public class EnemyMoveBullet : MonoBehaviour
{
    public Rigidbody2D bullet;
    public float moveSpeed = 20.0f;
    public float lifetime = 2f;
    void Start()
    {
        bullet = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bullet.linearVelocity = -transform.up * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            col.gameObject.SetActive(false);

            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
