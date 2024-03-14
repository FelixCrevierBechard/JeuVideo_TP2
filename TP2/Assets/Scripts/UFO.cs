using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UFO : MonoBehaviour
{
    [SerializeField] float Magnetude = 0.006f;
    [SerializeField] float frequence = 10f;
    [SerializeField] float speed = 7f;
    [SerializeField] float amplitude = 10f;
    float initTime;
    [SerializeField] float MaxTravelTime = 2f;
    [SerializeField] float FiringDelay = 1f;
    float Delay;
    [SerializeField] GameObject Star;
    // Start is called before the first frame update
    void Start()
    {
        initTime = Time.time;
        Delay = FiringDelay;
    }
    private void OnEnable()
    {
        initTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //gère la gestion de l'ufo au complet
        GestionDesactivation();
        GestionMouvement();
        GestionFiring();
    }

    private void GestionFiring()
    {
        if (Delay <= 0)
        {
            GameObject newStar = ObjectPool.instance.getPooledObject(Star);
            if (newStar != null)
            {
                newStar.transform.position = transform.position;
                newStar.SetActive(true);//fait spawn les UFO
            }
            Delay = FiringDelay;
        }
        Delay -= Time.deltaTime;
    }
    private void GestionDesactivation()
    {
        if (Time.time > initTime + MaxTravelTime)
            gameObject.SetActive(false);//désactive l'ufo
    }
    private void GestionMouvement()
    {
        transform.Translate(Vector2.left * amplitude * Mathf.Sin(Time.time * frequence) * Magnetude); //gère l'effet sin sur l'object
        transform.Translate(Vector2.down * speed * Time.deltaTime);//se gère de la descente de l'object
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet" || collision.gameObject.name == "Ship")
        {
            gameObject.SetActive(false);//désactive l'ufo
            if(collision.gameObject.name == "Bullet")
                collision.gameObject.SetActive(false); //désactive la balle
            Ship.instance.points += 5; //augmente les points du joueurs
            Ship.instance.nbAlienMort += 1; //augmente le nombre de mort
        }
    }
}
