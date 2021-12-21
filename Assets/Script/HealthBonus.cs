using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonus : MonoBehaviour
{
    private int speed;
    [SerializeField] private GameObject bulletPlayer;
    [SerializeField] private GameObject bulletBoss;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
    }

    //A chaque frame on actualise la position de l'objet bonus ou on le détruit
    void Update()
    {
        if (transform.position.z > HealthBonusManager.instance.GetEndPos().z) //s'il n'a pas encore atteint la limite de l'écran
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime); //on le fait avancer vers le bas
        }
        else //sinon on le détruits
        {
            Destroy(gameObject);
        }
    }
}
