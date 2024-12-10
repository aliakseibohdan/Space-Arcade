using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;
    public AudioClip explosion;
    public float rotationSpeed;
    public float minSpeed, maxSpeed;
    Rigidbody asteroid;
    GameManager gameManager;
    AudioSource source;

    void Start()
    {
        asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;

        var randomSpeed = Random.Range(minSpeed, maxSpeed);
        asteroid.velocity = new Vector3(0, 0, -randomSpeed);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        source = GameObject.Find("Scene SFX").GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Heart")) return;

        if (other.CompareTag("Boundary")) return;
        var explosionFX = Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
        explosionFX.GetComponent<Rigidbody>().velocity = asteroid.velocity;
        source.PlayOneShot(explosion);
        Destroy(gameObject);        

        /*if (other.CompareTag("Asteroid"))
        {
            Destroy(other.gameObject);
            return; // разлом астероидов
        }
        */

        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
            other.GetComponent<PlayerScript>().OnHit();
            return;
        }

        gameManager.IncreaseScore(10);
    }
}
