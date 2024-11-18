using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float xRange = 9.0f;
    public float zRange = 3.5f;
    private float speed = 0.3f;
    private float startDelay = 0.5f;
    private float repeatRate = 0.25f;
    private Rigidbody playerRb;
    public GameObject projectilePrefab;
    private int health = 10;
    public TextMeshProUGUI healthText;
    public bool isGameActive = true;
    public ParticleSystem smallExplosion;
    public ParticleSystem largeExplosion;
    public ParticleSystem trail;
    public AudioClip fireLaser;
    public AudioClip ouchie;
    public AudioClip fuckingDead;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBullet", startDelay, repeatRate);
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 4)
        {
            transform.position = new Vector3(4, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (isGameActive == true) { 
        transform.Translate(-Vector3.up * speed * horizontalInput);
        transform.Translate(Vector3.right * speed * verticalInput);

       
        }
   
        

    }
    void SpawnBullet()
    {
        if (isGameActive == true)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            playerAudio.PlayOneShot(fireLaser, 0.25f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isGameActive == true)
        {
            if (other.gameObject.CompareTag("Attack"))
            {
                Destroy(other.gameObject);
                health = health - 1;
                healthText.text = "Health: " + health;
                StartCoroutine(boom());
                playerAudio.PlayOneShot(ouchie, 1.0f);


            }
            if (other.gameObject.CompareTag("Fat"))
            {
                Destroy(other.gameObject);
                health = health - 4;
                healthText.text = "Health: " + health;
                StartCoroutine(boom());
                playerAudio.PlayOneShot(ouchie, 1.0f);
            }
            if (health < 1)
            {
                GameOver();
                //Debug.Log("get rekt");
            }
            //Debug.Log(health);
        }
        

    }

    void GameOver()
    {
        StartCoroutine(ded());
    }

    IEnumerator ded()
    {
        trail.Stop();
        smallExplosion.Play();
        largeExplosion.Play();
        playerAudio.PlayOneShot(fuckingDead, 1.0f);
        isGameActive = false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameOver");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator boom()
    {
        smallExplosion.Play();
        yield return new WaitForSeconds(1f);
        smallExplosion.Stop();
    }


}
