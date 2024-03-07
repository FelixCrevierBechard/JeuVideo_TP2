using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pointOfPlayer : MonoBehaviour
{
    [SerializeField] TMP_Text pointDuJoueur;
    // Start is called before the first frame update
    void Start()
    {
        pointDuJoueur.text = $"Vos points acquis dans la partie : {Ship.instance.points}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
