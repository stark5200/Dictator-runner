using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{

    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private int speed = 4;
    [SerializeField]
    private float lifeTime = 4f;

    [SerializeField]
    float slowDownEffect = 0.1f;
    [SerializeField]
    int slowDownTime = 50;

    public GameObject effect;

    public PlayerController player;

    private Shake shake;

    public GameObject explosionSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //player takes damage
            //player.health -= damage;
            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(explosionSound, transform.position, Quaternion.identity);
            player = other.GetComponent<PlayerController>();
            shake.camShake(0);

            //player slows down
            //player.slowDownEffect = slowDownEffect;
            //player.slowDownTime += slowDownTime; 
            Debug.Log(string.Format("Slow Down Time {0}, Slow Down Effect {1}", slowDownTime, slowDownEffect));
            player.SlowDown(slowDownEffect, slowDownTime);

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
