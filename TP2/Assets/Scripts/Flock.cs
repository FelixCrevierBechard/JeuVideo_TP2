using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    float initTime;
    [SerializeField] float MaxTravelTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        initTime = Time.time;
    }
    private void OnEnable()
    {
        initTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if(Time.time > initTime + MaxTravelTime)
            gameObject.SetActive(false);
    }

}
