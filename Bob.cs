using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    private float bounceSpeed = .4f;
    private float bounceVar = -1;
    private float lowerBound = 7.075f;
    private float upperBound = 7.525f;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   if (gameOver == false)
        {
            if (transform.position.x < lowerBound)
            {
                transform.position = new Vector3(lowerBound, transform.position.y, transform.position.z);
                bounceVar = -bounceVar;
            }
            if (transform.position.x > upperBound)
            {
                transform.position = new Vector3(upperBound, transform.position.y, transform.position.z);
                bounceVar = -bounceVar;
            }
            transform.Translate(bounceSpeed * bounceVar * Time.deltaTime, 0, 0);
            bounceSpeed += .000073f;
        }
    if(gameOver == true)
        {
            transform.position = new Vector3(7.4f, .75f, 0f);
        }
    }
}
