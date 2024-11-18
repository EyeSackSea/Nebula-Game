using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    public Material[] material;
    Renderer rend;
    public GameObject Cylinder;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            
            Debug.Log("hit!");
            StartCoroutine(white());
            Cylinder.GetComponent<Flash2>().oof();

        }
    }
    IEnumerator white()
    {
        rend.sharedMaterial = material[1];
        yield return new WaitForSeconds(0.1f);
        rend.sharedMaterial = material[0];
    }

}
