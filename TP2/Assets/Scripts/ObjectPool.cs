using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    List<GameObject> pool = new List<GameObject>();

    [SerializeField] GameObject[] objectAPool;
    [SerializeField] int[] numberAPool;

    public static ObjectPool instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    { //défini les objets dans l'objet pool
        for (int i = 0; i < Mathf.Min(objectAPool.Length, numberAPool.Length); i++)
            for (int j = 0; j < numberAPool[i]; j++)
            {
                GameObject obj = Instantiate(objectAPool[i]);
                obj.name = objectAPool[i].name;
                obj.SetActive(false);
                pool.Add(obj);
            }
    }

    public GameObject getPooledObject(GameObject typeObj)
    {
        //prendre les objects dans l'object pools
        for(int i = 0; i < pool.Count; i++)
        {
            if(typeObj.name == pool[i].name && !pool[i].activeInHierarchy)
                return pool[i];
        }
        return null; //CAN BE REPLACE BY CODE THAT CREATE A NEW ITEM
    }
}
