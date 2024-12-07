using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public Rigidbody2D bullet;
    public float moveSpeed = 10.0f;
    public float lifetime = 2f;

    void Start()
    {

        bullet = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bullet.linearVelocity = transform.up * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
 
        if (col.gameObject.name == "Enemy" || col.gameObject.name == "Enemy 1(Clone)")
        {
  
            col.gameObject.SetActive(false);

            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
