using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    [SerializeField] GameObject Bonus;
    [SerializeField] int mur = 11;
    [SerializeField] int plafond = 6;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Ship.instance.nbAlienMort >= 5)
        {
            GameObject.Instantiate(Bonus, new Vector3(UnityEngine.Random.Range(-mur, mur), plafond, 0), Quaternion.identity);
            //fait spawn un bonus a chaque 5 enemie mort
            Ship.instance.nbAlienMort = 0;
        }
    }
}
