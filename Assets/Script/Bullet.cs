using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bullet : MonoBehaviour
{
    private Vector3 bulletPos;
    [SerializeField] private int bulletSpeed;
    [SerializeField] private GameObject bonus;
    private float upBound;


    //On d�finit une limite de disparition des bullets
    void Start()
    {
        upBound = (float)((float)Screen.height - 25.0f);
    }

    //On d�finit la position du bullet � l'�cran par rapport � la cam�ra
    //et on appelle la m�thode de gestioin du bullet
    void Update()
    {
        bulletPos = Camera.main.WorldToScreenPoint(transform.position);
        bulletMove();
    }

    //M�thode qui g�re le comportement du bullet
    void bulletMove()
    {
        if(bulletPos.y < upBound) //si le bullet n'a pas encore atteint la limite de l'�cran
        {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime); //on le fait avancer vers le haut
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

        //Si le bullet entre en collision avec :

        //Un �nnemi, il dispara�t, fait dispara�tre l'ennemi et augmente le score
        if (other.tag == "Enemy") 
        {
            Destroy(other);
            Destroy(gameObject);
            GameManager.instance.addScore(100);
        }
        //Le Boss, il dispara�t et fais perdre des points de vie au boss 
        if(other.tag == "Boss")
        {
            Destroy(gameObject);
            GameManager.instance.BossDamage(-1);
        }
        //Un bonus, il est cens� ignorer la collision et passer au travers
        //Or cette ligne de code ne marche pas, les collisions sont g�r�es au niveau des layers via l'interface de unity
        if(other.tag == "Bonus")
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), other.GetComponent<Collider>(), true);
        }
    }

}
