using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReapeatingStaticBG : MonoBehaviour
{
    public GameObject player;

    public float startX;
    public float endX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        endX = player.transform.position.x + 16;
        startX = player.transform.position.x;

        if (transform.position.x <= endX)
        {
            Vector2 pos = new Vector2(startX, transform.position.y);
            transform.position = pos;
        }
    }
}
