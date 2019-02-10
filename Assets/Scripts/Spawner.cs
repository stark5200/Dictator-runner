using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;

    [SerializeField]
    private float startTimeBtwSpawn;
    [SerializeField]
    private float minTimeBtwSpawn;
    [SerializeField]
    private float decrementTimeBtwSpawn;
    private float timeBtwSpawn;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, obstaclePatterns.Length);
            Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            if (minTimeBtwSpawn <= startTimeBtwSpawn)
            {
                startTimeBtwSpawn -= decrementTimeBtwSpawn;
            }
        } else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
