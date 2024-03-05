using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float TravelSpeed = 10f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        if(rb == null)
            rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.forward * TravelSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * TravelSpeed * Time.deltaTime, Space.Self);
    }

    private void FixedUpdate()
    {
        
    }
}
