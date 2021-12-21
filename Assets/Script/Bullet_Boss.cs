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

    //On d�finit la position du bullet � l'�cran par rapport � la cam�ra
    //et on appelle la m�thode de gestioin du bullet
    void Update()
    {
        bulletPos = Camera.main.WorldToScreenPoint(transform.position);
        bulletMove();
    }

    //M�thode qui g�re le comportement du bullet du boss
    void bulletMove()
    {
        if (bulletPos.y > 0) //si le bullet n'a pas encore atteint la limite de l'�cran
        {
            transform.Translate(Vector3.back * bulletSpeed * Time.deltaTime); //on le fait avancer vers le bas
        }

        else //sinon on d�truit le bullet
        {
            Destroy(gameObject);
        }
    }

    //M�thode qui g�re le comportement des collisions du bullet
    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        //Si le bullet entre en collision avec le player
        //il dispara�t et faire perdre un point de vie au player
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            GameManager.instance.TakeDamage(-1);
        }
    }
}
