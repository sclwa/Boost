using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startPosition;
    [SerializeField] Vector3 movingVector;
    [SerializeField] [Range(0, 1)] float movingFactor;
    [SerializeField] float period;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon) return;

        movingFactor = Mathf.Sin(Time.time * 2 * Mathf.PI / period);
        transform.position = startPosition + movingFactor * movingVector;
    }
}
