using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    Vector2 Direction = Vector2.zero;
    [SerializeField] float Vitesse = 10f;
    [SerializeField] float FireRate = 8f;
    [SerializeField] GameObject Bullet;
    [SerializeField] Vector2 MuzzlePos = Vector2.zero;
    [SerializeField] float murDroite = 11;
    [SerializeField] float murGauche = -11;
    [SerializeField] float plafond = 5;
    [SerializeField] float sol = -5;
    public int nbAlienMort = 0;
    public int bonus = 1;
    float Fired = 0;
    float BulletDelay = 0;
    public int points = 0;

    public static Ship instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (bonus > 0)
        {
            if(transform.position.x + Direction.x < murDroite && transform.position.y + Direction.y < plafond&& transform.position.x + Direction.x > murGauche&& transform.position.y + Direction.y > sol)
                transform.Translate(Direction.normalized * Vitesse * Time.deltaTime, Space.World);

            if (Fired > 0 && BulletDelay <= 0)
            {
                GameObject newBullet = ObjectPool.instance.getPooledObject(Bullet); ;
                GameObject newBullet2;
                GameObject newBullet3;
                if (newBullet != null)
                {
                    if(bonus == 1)
                    {
                        newBullet = ObjectPool.instance.getPooledObject(Bullet);
                        newBullet.transform.position = (Vector2)transform.position + MuzzlePos;
                        newBullet.SetActive(true);
                    }
                    else if(bonus == 2)
                    {
                        newBullet = ObjectPool.instance.getPooledObject(Bullet);
                        newBullet.transform.position = (Vector2)transform.position + MuzzlePos - new Vector2(0.25f, 0);
                        newBullet.SetActive(true);
                        newBullet2 = ObjectPool.instance.getPooledObject(Bullet);
                        newBullet2.transform.position = (Vector2)transform.position + MuzzlePos + new Vector2(0.25f, 0);
                        newBullet2.SetActive(true);
                    }
                    else if(bonus >= 3)
                    {
                        newBullet = ObjectPool.instance.getPooledObject(Bullet);
                        newBullet.transform.position = (Vector2)transform.position + MuzzlePos;
                        newBullet.SetActive(true);
                        newBullet2 = ObjectPool.instance.getPooledObject(Bullet);
                        newBullet2.transform.position = (Vector2)transform.position + MuzzlePos + new Vector2(0.5f, 0);
                        newBullet2.SetActive(true);
                        newBullet3 = ObjectPool.instance.getPooledObject(Bullet);
                        newBullet3.transform.position = (Vector2)transform.position + MuzzlePos + new Vector2(-0.5f,0); 
                        newBullet3.SetActive(true);
                    }
                    BulletDelay = 1 / FireRate;
                }
            }
            else
                BulletDelay -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(1);
        }

    }

    public void Move(InputAction.CallbackContext context)
    {
        Direction = context.ReadValue<Vector2>();
    }
    public void Fire(InputAction.CallbackContext context)
    {
        Fired = context.ReadValue<float>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name != "Bullet"&&collision.gameObject.name != "Bonus"&&collision.gameObject.name != "Bonus(Clone)")
            bonus--;
    }
}
