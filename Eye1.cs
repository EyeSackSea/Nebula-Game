using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye1 : MonoBehaviour
{
    public bool GameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameOver == true)
        {
            transform.eulerAngles = new Vector3(
    transform.eulerAngles.x,
    transform.eulerAngles.y * -1,
    transform.eulerAngles.z);
            GameOver = false;
        }
    }

}
