using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] float MaxTravelTime = 10f;
    [SerializeField] float TravelSpeed = 10f;
    Rigidbody2D rb;
    Vector3 direction;
    float initTime;
    // Start is called before the first frame update
    void Start()
    {
        initTime = Time.time;
        if(Ship.instance != null)
            direction = (Ship.instance.transform.position - transform.position).normalized;
    }
    private void OnEnable()
    {
        initTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * TravelSpeed * Time.deltaTime, Space.Self);
        if (Time.time > initTime + MaxTravelTime)
            gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("star");
        if (collision.gameObject.name == "Bullet" || collision.gameObject.name == "Ship")
        {
            gameObject.SetActive(false);
            Ship.instance.points += 2;
        }
    }
}
