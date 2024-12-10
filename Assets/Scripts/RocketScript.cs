using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public GameObject rocketExplosion;
    [SerializeField]
    public float rotationSpeed;
    [SerializeField]
    float speed;
    Rigidbody rocket;

    void Start()
    {
        rocket = GetComponent<Rigidbody>();
        rocket.angularVelocity = Random.insideUnitCircle * rotationSpeed;
        rocket.velocity = new Vector3(0, 0, -speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().GetRocket();
            Instantiate(rocketExplosion, other.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
