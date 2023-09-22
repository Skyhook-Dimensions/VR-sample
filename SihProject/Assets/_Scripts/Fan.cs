using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fan : MonoBehaviour
{
    public Transform toRotate;
    public float rotationSpeed;
    public float stoppingSpeed;
    float lifeTime;
    Rigidbody rb;
    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        System.Random random = new System.Random();
        float randomFloat = (float)random.NextDouble() * player.timeRadomize;
        lifeTime = player.timeTillDisaster + randomFloat;
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (rotationSpeed > 0)
        {
            toRotate.Rotate(new Vector3(0, Time.deltaTime * rotationSpeed, 0));
            if (lifeTime < 0)
            {
                rotationSpeed -= Time.deltaTime * stoppingSpeed;
                rb.useGravity = true;
            }
            lifeTime -= Time.deltaTime;
        }
    }
}
