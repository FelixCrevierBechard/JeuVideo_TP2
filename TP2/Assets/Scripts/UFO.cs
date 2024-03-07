using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UFO : MonoBehaviour
{
    [SerializeField] float Magnetude = 0.006f;
    [SerializeField] float frequence = 10f;
    [SerializeField] float speed = 10f;
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
                newStar.SetActive(true);
            }
            Delay = FiringDelay;
        }
        Delay -= Time.deltaTime;
    }
    private void GestionDesactivation()
    {
        if (Time.time > initTime + MaxTravelTime)
            gameObject.SetActive(false);
    }
    private void GestionMouvement()
    {
        transform.Translate(Vector2.left * Mathf.Sin(Time.time * frequence) * Magnetude);
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("UFO");
        if (collision.gameObject.name == "Bullet" || collision.gameObject.name == "Ship")
        {
            gameObject.SetActive(false);
            Ship.instance.points += 5;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {

    }


}
