using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gère le spawn et la destruction des bonus avec le temps;
        if (transform.position.y > -6)
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        else
            Destroy(transform.gameObject);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ship"|| collision.gameObject.name == "Bullet")
        {
            //gère la destruction du bonus et l'ajout du bonus au joueur ainsi des points
            Destroy(transform.gameObject);
            Ship.instance.points += 2;
            Ship.instance.bonus += 1;
        }
    }
}
