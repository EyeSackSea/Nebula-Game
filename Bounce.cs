using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float zRange = 4.5f;
    private float speed = 7f;
    private float bounceSpeed = 10f;
    private int bound = -10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
            bounceSpeed = 10f;
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
            bounceSpeed = -10f;
        }

    
        transform.Translate(-speed * Time.deltaTime, 0, bounceSpeed * Time.deltaTime);

        if (transform.position.x < bound)
        {
            Destroy(gameObject);
        }
    }
}
