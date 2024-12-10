using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public GameObject heartExplosion;
    [SerializeField]
    public float rotationSpeed;
    [SerializeField]
    float speed;
    Rigidbody heart;

    void Start()
    {
        heart = GetComponent<Rigidbody>();
        heart.angularVelocity = Random.insideUnitCircle * rotationSpeed; // вращение в рандомную сторону
        heart.velocity = new Vector3(0, 0, -speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().GetBonus();
            Instantiate(heartExplosion, other.transform.position, Quaternion.identity); // если корабль, показать эфф
            Destroy(gameObject);
        }
    }
}
