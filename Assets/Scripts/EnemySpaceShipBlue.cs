using UnityEngine;

public class EnemySpaceShipBlue : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float leftlimitCoordinate = -3f;
    [SerializeField] float rightScreenlimit = 3f;
    bool isGoingLeft = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = isGoingLeft ? Vector2.left : Vector2.right;
        transform.Translate(direction * speed * Time.deltaTime);

        if (isGoingLeft && (transform.position.x < leftlimitCoordinate))
        {
            isGoingLeft = false;
        }

        if (!isGoingLeft && (transform.position.x > rightScreenlimit))
        {
            Destroy(gameObject);
        }

        //if (isGoingLeft)
        //{
        //    transform.Translate(Vector2.left * speed * Time.deltaTime);
        //}
        //else
        //{
        //    transform.Translate(Vector2.right * speed * Time.deltaTime);
        //}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
