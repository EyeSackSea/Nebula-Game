using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public float speed;
    private float rightBound = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        if (transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
    }
}
