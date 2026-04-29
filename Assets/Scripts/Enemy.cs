using NUnit.Framework;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float amp = 1.5f;
    [SerializeField] float freq = 2f;
    [SerializeField] float leftLimitCoordinate = -3f;
    [SerializeField] float rightScreenLimit = 3f;
    [SerializeField] Animator anim;
    [SerializeField] int ScorePoints = 100;
    [SerializeField] AudioSource SFX;
    float startY;
    float timeOffset;
    bool isHit = false;
    bool isgoingleft = true;
    CircleCollider2D colision;

    void Awake()
    {
        colision = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (isHit)
        {
            return;
        }

        Vector2 direction = isgoingleft ? Vector2.left : Vector2.right;
        transform.Translate(direction * speed * Time.deltaTime);

        float sinValue = Mathf.Sin((Time.time * freq)+timeOffset);
        float newY = startY + sinValue * amp;

        transform.position = new Vector3(transform.position.x, newY,transform.position.z);

        if (isgoingleft && transform.position.x < leftLimitCoordinate)
        {
            isgoingleft = false;
        }

        if (!isgoingleft && transform.position.x > rightScreenLimit)
        {
            colision.enabled = false;
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("PlayerShot"))
        {
            Global.instance.AddScore(ScorePoints);
            Global.instance.AddSpecial(0.1f);
            isHit=true;
            colision.enabled = false;
            anim.SetBool("IsHit",true);
            SFX.Play();
            speed = 0;
            
            //Destroy(collision.collider.gameObject);
        }
        if(collision.collider.CompareTag("Player"))
        {
            colision.enabled = false;
            isHit=true;
            anim.SetBool("IsHit",true);
            SFX.Play();
            speed = 0;
        }
    }

    void OnEnemyDefeat()
    {
        
        Destroy(gameObject);
    }
}
