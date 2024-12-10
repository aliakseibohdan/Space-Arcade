using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject rocket;
    public GameObject asteroid;
    public GameObject heart;
    [SerializeField]
    public float minDelay, maxDelay;
    [SerializeField]
    float minDelayHeart, maxDelayHeart;
    [SerializeField]
    float minDelayRocket, maxDelayRocket;
    float nextLaunchTimeAsteroid;
    float nextLaunchTimeHeart;
    float nextLaunchTimeRocket;

    void Update()
    {
        if (Time.time > nextLaunchTimeAsteroid)
        {
            Instantiate(asteroid, MakePosition(), Quaternion.identity);
            nextLaunchTimeAsteroid = Time.time + Random.Range(minDelay, maxDelay);
        }
        if (Time.time > nextLaunchTimeHeart)
        {
            Instantiate(heart, MakePosition(), Quaternion.identity);
            var delayBonus = Random.Range(minDelayHeart, maxDelayHeart);
            nextLaunchTimeHeart = Time.time + delayBonus;
        }
        if (Time.time > nextLaunchTimeHeart)
        {
            Instantiate(rocket, MakePosition(), Quaternion.identity);
            var delayBonus = Random.Range(minDelayRocket, maxDelayRocket);
            nextLaunchTimeHeart = Time.time + delayBonus;
        }
    }

    Vector3 MakePosition()
    {
        var positionY = transform.position.y;
        var positionZ = transform.position.z - 10;
        var positionX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
        var newPosition = new Vector3(positionX, positionY, positionZ);
        return newPosition;
    }
}