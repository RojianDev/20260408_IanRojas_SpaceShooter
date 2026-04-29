using UnityEngine;

public class EliteEnemy : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float amp = 1.5f;
    [SerializeField] float freq = 2f;
    [SerializeField] float leftLimitCoordinate = -3f;
    [SerializeField] float rightScreenLimit = 3f;
    [SerializeField] Animator anim;
    [SerializeField] int hits = 3;
    [SerializeField] int ScorePoints = 250;
    [SerializeField] AudioSource SFX;

    CircleCollider2D colision;

    float startY;
    float timeOffset;
    bool isHit = false;
    bool isgoingleft = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Update is called once per frame
    void Awake()
    {
        colision = GetComponent<CircleCollider2D>();
    }

    void Start()
    {
        startY = transform.position.y;
        timeOffset = Random.Range(0f, Mathf.PI * 2);
    }

    void Update()
    {
        if(isHit)
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
            hits --;
            if (hits <=0 )
            {
                Global.instance.AddScore(ScorePoints);
                Global.instance.AddSpecial(0.3f);
                SFX.Play();
                isHit = true;
                colision.enabled = false;
                anim.SetBool("IsDeath",true);
                speed = 0;
            }
            
            
            //Destroy(collision.collider.gameObject);
        }
        if (collision.collider.CompareTag("Player"))
        {
            isHit = true;
            colision.enabled = false;
            anim.SetBool("IsDeath",true);
            SFX.Play();
            speed = 0;
        }
    }

    void OnEnemyDefeat()
    {
        
        Destroy(gameObject);
    }
}
