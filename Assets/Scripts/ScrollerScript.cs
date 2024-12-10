using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollerScript : MonoBehaviour
{

    public float speedScrolling;
    Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // момент старта игры, где находится фон 
    }

    void Update()
    {
        var offset = Mathf.Repeat(Time.time * speedScrolling, 150);
        transform.position = startPosition + Vector3.back * offset;
    }
}