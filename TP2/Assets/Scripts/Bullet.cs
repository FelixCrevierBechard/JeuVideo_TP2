using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float TravelSpeed = 10f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        if(rb == null)
            rb = GetComponent<Rigidbody2D>(); //on lui donne un rigidbody en 2d
        rb.velocity = transform.forward * TravelSpeed; //on change sa velocity
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * TravelSpeed * Time.deltaTime, Space.Self); //déplace la balle
    }

}
