using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Vector2 targetPos;

    public int health = 3;

    [SerializeField]
    private float yIncrement = 0.65f;

    [SerializeField]
    private float moveTowardSpeed = 100f;

    [SerializeField] private float maxHeight = 1.4f;
    [SerializeField] private float minHeight = -1.4f;

    public GameObject upEffect;
    public GameObject downEffect;

    private Shake shake;

    public Text healthDisplay;

    public GameObject gameOver;

    public GameObject moveSound;

    // Start is called before the first frame update
    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = "HP:"+health.ToString();
        if (health <= 0)
        {
            Debug.Log("Game Over");
            gameOver.SetActive(true);
            Destroy(gameObject);

        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && ((transform.position.y + yIncrement) < maxHeight))
        {
            targetPos = new Vector2(transform.position.x, transform.position.y + yIncrement);
            Instantiate(upEffect, transform.position, Quaternion.identity);
            Instantiate(moveSound, transform.position, Quaternion.identity);
            shake.camShake(1);
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && ((transform.position.y - yIncrement) > minHeight))
        {
            targetPos = new Vector2(transform.position.x, transform.position.y - yIncrement);
            Instantiate(downEffect, transform.position, Quaternion.identity);
            Instantiate(moveSound, transform.position, Quaternion.identity);
            shake.camShake(1);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveTowardSpeed * Time.deltaTime);
    }
}
