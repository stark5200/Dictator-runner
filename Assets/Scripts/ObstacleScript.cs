using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{

    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private int speed = 5;
    [SerializeField]
    private float lifeTime = 4f;

    public GameObject effect;

    public PlayerController player;

    private Shake shake;

    public GameObject explosionSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //player takes damage
            Instantiate(effect, transform.position, Quaternion.identity);
            Instantiate(explosionSound, transform.position, Quaternion.identity);
            player = other.GetComponent<PlayerController>();
            player.health -= damage;
            shake.camShake(0);
            Debug.Log(other.GetComponent<PlayerController>().health);
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
