using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Vector2 targetPos;
    private Vector2 moveRight;
    private Rigidbody2D rb;

    //public int health = 10;
    public float speed = 3f;
    public float crowdDist = 0f;
    public float startingSpeed;

    public int slowDownTime = 0;
    public float slowDownEffect = 0f;

    [SerializeField]
    private float yIncrement = 1.3f;

    [SerializeField]
    private float moveTowardSpeed = 50f;

    [SerializeField] private float maxHeight = 1.4f;
    [SerializeField] private float minHeight = -1.4f;

    public GameObject upEffect;
    public GameObject downEffect;

    private Shake shake;

    public Text distanceDisplay;

    public GameObject crowd;
    public GameObject gameOver;

    public GameObject moveSound;

    // Start is called before the first frame update
    void Start()
    {
        startingSpeed = speed;
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        crowd = GameObject.FindGameObjectWithTag("Crowd");
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        crowdDist = transform.position.x - crowd.transform.position.x;
        distanceDisplay.text = "Distance:" + (crowdDist*5-5.55f).ToString("F1");
        //transform.position += transform.right * speed * Time.deltaTime;
        //moveRight = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        //rb.velocity = new Vector2(speed * Time.deltaTime, 0);
        /*if (health <= 0)
        {
            Debug.Log("Game Over");
            gameOver.SetActive(true);
            Destroy(gameObject);

        }*/
        if (Input.GetKeyDown(KeyCode.UpArrow) && ((transform.position.y + yIncrement) < maxHeight))
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + yIncrement);
            Instantiate(upEffect, transform.position, Quaternion.identity);
            Instantiate(moveSound, transform.position, Quaternion.identity);
            shake.camShake(1);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, moveTowardSpeed * Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && ((transform.position.y - yIncrement) > minHeight))
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - yIncrement);
            Instantiate(downEffect, transform.position, Quaternion.identity);
            Instantiate(moveSound, transform.position, Quaternion.identity);
            shake.camShake(1);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, moveTowardSpeed * Time.deltaTime);
        }

        //apply slow down player from obstacleScript
        if (slowDownTime > 0) {
            speed -= slowDownEffect;
            slowDownEffect = 0;
            slowDownTime--;
        } 

        if (slowDownTime == 0)
        {
            slowDownEffect = 0f;
            speed = startingSpeed;
        }
    }
}
