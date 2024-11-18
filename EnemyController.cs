using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public Slider slider;
    private int bossHealth = 300;
    private Rigidbody bossRb;
    float rotationSpeed = 0.1f;
    public GameObject player;
    public GameObject cube;
    public GameObject cylinder1;
    public GameObject cylinder2;
    public ParticleSystem Explosion1;
    public ParticleSystem Explosion2;
    public ParticleSystem Explosion3;
    public AudioClip death;
    private AudioSource enemyAudio;


    // Start is called before the first frame update
    void Start()
    {
        bossRb = GetComponent<Rigidbody>();
        enemyAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, rotationSpeed, 0);
        rotationSpeed += .0015f; 
    }

    void OnTriggerEnter(Collider other)
    {   if (bossHealth >= 12)
        {
            if (other.gameObject.CompareTag("Bullet"))
            {
                Destroy(other.gameObject);
                bossHealth = bossHealth - 1;
                //Debug.Log(bossHealth);
                slider.value = bossHealth;
                if (bossHealth < 12)
                {
                    StartCoroutine(winner());
                }

            }
        }
        


    }
    IEnumerator winner()
    {
        player.GetComponentInChildren<PlayerController>().isGameActive = false;
        cube.GetComponentInChildren<Bob>().gameOver = true;
        cylinder1.GetComponentInChildren<Eye1>().GameOver = true;
        cylinder2.GetComponentInChildren<Eye1>().GameOver = true;
        enemyAudio.PlayOneShot(death, 1.0f);
        Explosion1.Play();
        yield return new WaitForSeconds(.5f);
        Explosion2.Play();
        yield return new WaitForSeconds(.5f);
        Explosion3.Play();
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Winner");
    }
}
