using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera m_MainCamera;
    [SerializeField] private int m_VerticalSpeed;
    [SerializeField] private int m_HorizontalSpeed;
    [SerializeField] private int m_Speed;
    [SerializeField] private float fireSpeed;
    [SerializeField] private GameObject bullet;
    [SerializeField] private AudioClip sound;
    [SerializeField] private AudioSource piste;

    private Vector3 screenPos;
    private float rightBound;
    private float leftBound;
    private float upBound;
    private float downBound;
    private Stopwatch stopWatch;
    

    //On initialise la position des limites de d�placement du player
    void Start()
    {
        rightBound = (float)((float)Screen.width * 80.0 / 100.0);
        leftBound = (float)((float)Screen.width * 20.0 / 100.0);
        upBound = (float)((float)Screen.height * 80.0 / 100.0);
        downBound = (float)((float)Screen.height * 10.0 / 100.0);

        piste.volume = 0.1f;
    }


    //On actualise la position du player � l'�cran par rapport � la cam�ra principale
    //et on appelle la m�thode de gestion de ses comportements
    void Update()
    {
        screenPos = m_MainCamera.WorldToScreenPoint(transform.position);
        playerControl();
    }
    

    //On instancie et lance un compteur pour g�rer la cadence de tirs du player
    private void Awake()
    {
        stopWatch = new Stopwatch();
        stopWatch.Start();
    }


    void playerControl()
    {

        if (Input.GetKey(KeyCode.UpArrow)) //Si la touche fl�che du haut est press�e
        {
            if (screenPos.y < upBound) //si le player n'a pas atteint la limite du haut
            {
                transform.Translate(Vector3.forward * m_VerticalSpeed * Time.deltaTime); //on le fait avancer vers le haut
            }
            

        }        
        if (Input.GetKey(KeyCode.LeftArrow)) //Si la touche fl�che de gauche est press�e
        {
            if (screenPos.x > leftBound) //si le player n'a pas atteint la limite de gauche
            {
                transform.Translate(Vector3.left * m_HorizontalSpeed * Time.deltaTime); //on le fait avancer vers la gauche
            }

        }
        if (Input.GetKey(KeyCode.RightArrow)) //Si la touche fl�che de droite est press�e
        {
            if (screenPos.x < rightBound) //si le player n'a pas atteint la limite de droite
                transform.Translate(Vector3.right * m_HorizontalSpeed * Time.deltaTime); //on le fait avancer vers la droite
        }
        if (Input.GetKey(KeyCode.DownArrow)) //Si la touche fl�che du bas est press�e
        {
            if (screenPos.y > downBound) //si le player n'a pas atteint la limite du bas
                transform.Translate(Vector3.back * m_VerticalSpeed * Time.deltaTime); //on le fait avancer vers le bas
        }

        if(Input.GetKey(KeyCode.Space)) //Si la touche barre espace est press�e
        {
            if (stopWatch.ElapsedMilliseconds >= fireSpeed) //si le compteur a d�pass� le d�lai de cool down de la cadence de tir 
            {
                piste.PlayOneShot(sound); //on joue le son du tir
                //on cr�e deux bullets
                Instantiate(bullet, new Vector3 ((transform.position.x)-1.0f, transform.position.y, (transform.position.z)+3.0f), Quaternion.identity);
                Instantiate(bullet, new Vector3 ((transform.position.x)+1.0f, transform.position.y, (transform.position.z)+3.0f), Quaternion.identity);
              
                stopWatch.Restart(); //on red�marre le compteur pour la cadence de tir
            }
        }

    }

    //M�thode qui g�re les collision du player
    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        //Si le player entre en collision avec :
        //Un ennemi, il le d�truit et perd un point de vie
        if(other.tag == "Enemy")
        {
            Destroy(other);
            GameManager.instance.TakeDamage(-1);
        }
        //Avec un objet du layer 11, "Boss"
        //Il perd un point de vie, cependant cette ligne de code n'a aucun impact
        if (other.layer == 11)
        {
            GameManager.instance.TakeDamage(-1);
        }
        //Un bonus, il d�truit le bonus et regagne un point de, sauf s'il a d�j� tout ses points de vie
        if(other.tag == "Bonus")
        {
            Destroy(other);
            if(GameManager.instance.healthP != GameManager.instance.maxHealthP)
            {
                GameManager.instance.TakeDamage(1);
            }
        }
    }
}
