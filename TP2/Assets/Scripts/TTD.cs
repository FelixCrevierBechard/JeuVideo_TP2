using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTD : MonoBehaviour
{
    [SerializeField] float MaxTravelTime = 2f;
    float initTime;
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
        if(Time.time > initTime + MaxTravelTime)
            gameObject.SetActive(false);
    }
}
