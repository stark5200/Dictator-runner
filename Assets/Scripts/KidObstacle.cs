using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidObstacle : MonoBehaviour
{
    [SerializeField]
    private int speed = 5;
    [SerializeField]
    private float lifeTime = 4f;

    public float speedUpEffect = 0.3f;
    public int speedUpTime = 80;

    public float crowdSpeedUpEffect = 0.03f;
    public int crowdSpeedUpDelay = 100;

    public CrowdScript crowd;

    public GameObject effect;

    public PlayerController player;

    private Shake shake;

    public GameObject explosionSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //instantiate objects
            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(explosionSound, transform.position, Quaternion.identity);
            player = other.GetComponent<PlayerController>();
            shake.camShake(0);

            //crowd and player speed up 
            player.slowDownEffect = -speedUpEffect;
            player.slowDownTime += speedUpTime;

            crowd = GameObject.FindGameObjectWithTag("Crowd").GetComponent<CrowdScript>();

            Debug.Log("Speed = " + crowd.speed);
            Debug.Log("SpeedUpEffect = " + crowd.speedUpEffect);
            Debug.Log("SpeedUpDelay = " + crowd.speedUpDelay);

            crowd.speedUpDelay = crowdSpeedUpDelay;
            crowd.speedUpEffect = crowdSpeedUpEffect;

            Debug.Log("Speed = " + crowd.speed);
            Debug.Log("SpeedUpEffect = " + crowd.speedUpEffect);
            Debug.Log("SpeedUpDelay = " + crowd.speedUpDelay);

            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
