﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidObstacle : MonoBehaviour
{
    [SerializeField]
    private int speed = 5;
    [SerializeField]
    private float lifeTime = 4f;

    [SerializeField]
    float speedUpEffect = 0.3f;
    [SerializeField]
    int speedUpTime = 80;
    [SerializeField]
    float crowdSpeedUpEffect = 0.08f;
    [SerializeField]
    int crowdSpeedUpDelay = 100;

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
            player.SlowDown(-speedUpEffect, speedUpTime);

            crowd = GameObject.FindGameObjectWithTag("Crowd").GetComponent<CrowdScript>();
            crowd.SpeedUp(crowdSpeedUpEffect, crowdSpeedUpDelay);

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
