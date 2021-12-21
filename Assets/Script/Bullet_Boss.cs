using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Boss : MonoBehaviour
{
    private Vector3 bulletPos;
    [SerializeField] private int bulletSpeed = 10;
    [SerializeField] private GameObject bonus;

    void Start()
    {
        
    }

    //On définit la position du bullet à l'écran par rapport à la caméra
    //et on appelle la méthode de gestioin du bullet
    void Update()
    {
        bulletPos = Camera.main.WorldToScreenPoint(transform.position);
        bulletMove();
    }

    //Méthode qui gère le comportement du bullet du boss
    void bulletMove()
    {
        if (bulletPos.y > 0) //si le bullet n'a pas encore atteint la limite de l'écran
        {
            transform.Translate(Vector3.back * bulletSpeed * Time.deltaTime); //on le fait avancer vers le bas
        }

        else //sinon on détruit le bullet
        {
            Destroy(gameObject);
        }
    }

    //Méthode qui gère le comportement des collisions du bullet
    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        //Si le bullet entre en collision avec le player
        //il disparaît et faire perdre un point de vie au player
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            GameManager.instance.TakeDamage(-1);
        }
    }
}
