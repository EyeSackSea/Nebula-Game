using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash2 : MonoBehaviour
{
    public Material[] material;
    Renderer rend;
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
    public void oof()
    {
        StartCoroutine(grey());
    }
    IEnumerator grey()
    {
        rend.sharedMaterial = material[1];
        yield return new WaitForSeconds(0.1f);
        rend.sharedMaterial = material[0];
    }
}
