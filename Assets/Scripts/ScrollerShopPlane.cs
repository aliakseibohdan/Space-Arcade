using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollerShopPlane : MonoBehaviour
{

    public float speedScrolling;
    Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        var offset = Mathf.Repeat(Time.time * speedScrolling, 70);
        transform.position = startPosition + Vector3.down * offset;
    }
}
