using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = -7.0f;
    private float leftBound = -25;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        transform.Rotate(0, 5, 0);
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
