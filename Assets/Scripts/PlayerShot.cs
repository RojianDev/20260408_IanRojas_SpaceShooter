using UnityEngine;

public class PlayerShot : MonoBehaviour
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
        rb2d.linearVelocity = Vector2.right * speed;
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.collider.CompareTag("Enemy")||collision.collider.CompareTag("EliteEnemy"))
        {
            animator.SetBool("IsHit",true);
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (collision.collider.CompareTag("PlayerShot"))
        {
            return;
        }
        
    }

    void OnAnimationFinish()
    {
        Destroy(gameObject);
    }
}
