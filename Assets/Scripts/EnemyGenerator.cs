using System.Collections;
//using Unity.Mathematics;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject prefabEnemy;
    [SerializeField] GameObject EliteEnemy;
    [SerializeField] GameObject Asteroids;
    [SerializeField] float timeBetweenShips = 3f;
    [SerializeField] Transform top;
    [SerializeField] Transform bottom;
    [SerializeField] int MaxEnemies;
    [SerializeField] float TimetoMin = 180f;
    [SerializeField] float minTimeBetweenShips = 0.6f;

    private float currentTime;
 
    void Start()
    {
        currentTime = timeBetweenShips;
        StartCoroutine(Generate());
        StartCoroutine(DecreaseSpawnTimer());
    }

    IEnumerator DecreaseSpawnTimer()
    {
        float elapsedTime = 0f;
        while(currentTime > minTimeBetweenShips)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime/TimetoMin);
            currentTime = Mathf.Lerp(timeBetweenShips, minTimeBetweenShips,t);
            yield return null;
        }

        currentTime = minTimeBetweenShips;
    }
    IEnumerator Generate()
    {
        int currentEnemys = 0;
        while (true)
        {
            
            yield return new WaitForSeconds(currentTime);
            Vector3 position = Vector3.Lerp(top.position,bottom.position, Random.Range(0f, 2.5f));
            if (currentEnemys >= MaxEnemies)
            {
                Instantiate(EliteEnemy, position, Quaternion.identity);   
                currentEnemys = 0;
            }
            else
            {
                Instantiate(prefabEnemy, position, Quaternion.identity);
                currentEnemys ++;
            }
            
        }  
    }


}
