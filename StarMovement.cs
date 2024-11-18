using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMovement : MonoBehaviour
{
    private float speed = 4f;
    private int bound = -20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);

        if (transform.position.x < bound)
        {
            Destroy(gameObject);
        }
    }
}
