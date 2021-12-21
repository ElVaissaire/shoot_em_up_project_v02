using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private int speed;
    

    void Start()
    {
        speed = 13;
    }

    //A chaque frame, on actualise la position de l'objet "Enemy"
    void Update()
    {
        if (transform.position.z > EnemiesManager.instance.GetEndPos().z) //si l'ennemi n'a pas atteint la position en z de fin
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime); //on le fait avancer vers le bas
        }
        else //sinon on le détruit
        {
            Destroy(gameObject);
            GameManager.instance.TakeDamage(-1); //le player perd un point de vie si un ennemi arrive à passer la limite de l'écran
        }
    }
}
