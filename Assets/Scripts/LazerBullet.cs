using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBullet : MonoBehaviour
{
    public float pushBullet;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, pushBullet);
    }
}