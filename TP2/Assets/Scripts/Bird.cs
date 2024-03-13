using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet"||collision.gameObject.name == "Ship")
        {
            gameObject.SetActive(false);
            Ship.instance.points += 2;
            Ship.instance.nbAlienMort += 1;
        }
    }
}
