using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour
{
    Vector2 Direction = Vector2.zero;
    [SerializeField] float Vitesse = 1f;
    [SerializeField] float FireRate = 8f;
    [SerializeField] GameObject Bullet;
    [SerializeField] Vector2 MuzzlePos = Vector2.zero;
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
        transform.Translate(Direction.normalized * Vitesse * Time.deltaTime, Space.World);

        if (Fired > 0 && BulletDelay <= 0)
        {
            GameObject newBullet = ObjectPool.instance.getPooledObject(Bullet);
            if(newBullet != null )
            {
                newBullet.transform.position = (Vector2)transform.position + MuzzlePos;
                newBullet.SetActive(true);
            }
            
            BulletDelay = 1 / FireRate;
        }
        else
            BulletDelay -= Time.deltaTime;
    }

    public void Move(InputAction.CallbackContext context)
    {
        Direction = context.ReadValue<Vector2>();
    }
    public void Fire(InputAction.CallbackContext context)
    {
        Fired = context.ReadValue<float>();
    }
}
