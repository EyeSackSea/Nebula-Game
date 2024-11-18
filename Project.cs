using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project : MonoBehaviour
{
    private float speed = -15.0f;
    private float leftBound = -15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
