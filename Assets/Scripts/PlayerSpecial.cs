using UnityEngine;

public class PlayerSpecial : MonoBehaviour
{
    private float speed = 3f;
    [SerializeField] Animator animator;
    Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    
        if (collision.collider.CompareTag("PlayerShot"))
        {
            return;
        }
        if (collision.collider.CompareTag("Enemy")||collision.collider.CompareTag("EliteEnemy"))
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
        
    }

    void OnAnimationFinish()
    {
        Destroy(gameObject);
    }
}

