using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topple : MonoBehaviour
{
    public Transform topplingPos;
    public float topplingForce;
    public enum Direction { left,right,forward,backward};
    public Direction direction;
    float lifeTime;
    Player player;
    Rigidbody rb;

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
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            rb.AddForceAtPosition(topplingForce * Vector3.up, topplingPos.position);
            if (direction == Direction.right) rb.AddForceAtPosition(topplingForce * Vector3.right, topplingPos.position);
            else if(direction == Direction.left) rb.AddForceAtPosition(-1*topplingForce * Vector3.right, topplingPos.position);
            else if(direction == Direction.forward) rb.AddForceAtPosition(topplingForce * Vector3.forward, topplingPos.position);
            else if(direction == Direction.backward) rb.AddForceAtPosition(-1*topplingForce * Vector3.right, topplingPos.position);
            transform.GetComponent<Topple>().enabled = false;
        }
    }
}
