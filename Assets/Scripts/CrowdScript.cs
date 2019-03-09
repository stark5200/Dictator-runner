using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdScript : MonoBehaviour
{
    public float speed = 3f;
    public float distance = 0f;
    public GameObject gameOver;
    public GameObject player;
    public GameObject scoreManager;

    public int speedUpDelay;
    public float speedUpEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameOver.SetActive(true);
            Debug.Log("Game Over");
            scoreManager = GameObject.FindGameObjectWithTag("Score Manager");
            scoreManager.GetComponent<ScoreManager>().scoreIsActive = false;
            Destroy(other);
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        speedUpDelay = 0;
        speedUpEffect = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        distance = player.transform.position.x - transform.position.x;
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (speedUpDelay > 0)
        {
            speedUpDelay--;
            if (speedUpDelay == 0)
            {
                speed += speedUpEffect;
            }
        }
    }
}