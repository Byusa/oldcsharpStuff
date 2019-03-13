using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour {
    
    private Vector2 startPosition;
    private Vector2 newPosition;

    [SerializeField] private int speed = 10;
    [SerializeField] private int maxDistance = 200;

    void Start()
    {
        startPosition = transform.position;
        newPosition = transform.position;
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x+maxDistance * Mathf.Sin(Time.time * speed),transform.position.y);
    }
}
