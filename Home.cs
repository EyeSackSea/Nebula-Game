using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    private float speed = 6f;
    private int bound = -10;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float homeDirection = (player.transform.position.z - transform.position.z);
        transform.Translate(-speed * Time.deltaTime, 0, homeDirection * Time.deltaTime * 3);
        if (transform.position.x < bound)
        {
            Destroy(gameObject);
        }
    }
}
