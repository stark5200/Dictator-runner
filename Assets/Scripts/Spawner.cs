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

    public GameObject player;
    private Vector2 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = new Vector2(player.transform.position.x + 12, 0);

        if (timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, obstaclePatterns.Length);
            Instantiate(obstaclePatterns[rand], playerPos, Quaternion.identity);
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
