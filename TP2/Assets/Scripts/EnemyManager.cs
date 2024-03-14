using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] public GameObject[] typeEnemies;
    [SerializeField] float SpawnDelay = 2f;
    float Delay;
    float width = 20f;
    float minXPos;
    float maxXPos;
    public static EnemyManager instance;
    // Start is called before the first frame update
    void Start()
    {
        minXPos = -width / 2;
        maxXPos = width / 2;
        Delay = SpawnDelay;
        if(instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update() 
    {
        if(Delay <= 0) //s'occupe de faire spawn aléatoire et à une position aléatoire entre deux bornes un enemie a x nombre de temps
        {
            int i = Random.Range(0, typeEnemies.Length);
            GameObject newEnemy = ObjectPool.instance.getPooledObject(typeEnemies[i]);
            if(newEnemy != null)
            {
                float xPos = Random.Range(minXPos, maxXPos);
                newEnemy.transform.position = new Vector2(xPos, 7f);
                foreach (Transform child in newEnemy.transform)
                {
                    child.gameObject.SetActive(true);
                }
                newEnemy.SetActive(true);
            }
            Delay = SpawnDelay;
        }
        Delay -= Time.deltaTime;
    }
}
