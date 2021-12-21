using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class boss : MonoBehaviour
{

    //private int init;
    private int sens = 0;
    private Stopwatch newStopWatch;

    [SerializeField] private int hori_speed;
    [SerializeField] private int vert_speed;
    [SerializeField] private GameObject bullet;
    [SerializeField] private AudioClip sound;
    [SerializeField] private AudioSource piste;
    [SerializeField] private float fireSpeed = 10000.0f;


    //Démarrage d'un compteur qui nous permet
    //de gérer la cadence de tir

    private void Awake()
    {
        newStopWatch = new Stopwatch();
        newStopWatch.Start();
    }

    //Initialisation du son produit par le boss (son des bullets)
    void Start()
    {
        piste = GetComponent<AudioSource>();
        piste.volume = 0.1f;
    }

  
    void Update()
    {
        BossControl();
    }


    //Méthode qui gère les déplacements et les tir du boss
    void BossControl()
    {
        //fais avancer le boss verticalement jusqu'à l'écran et s'arrête à la position stopPos
        if (transform.position.z > BossManager.instance.getStopPos().z)
        {
            transform.Translate(Vector3.back * vert_speed * Time.deltaTime);
        }
        
        //Dans le cas où il est suffisamment avancé
        else
        {
            if(sens == 0) //direction du boss vers la gauche
            {
                if(transform.position.x > -15)//on fait avancer le boss vers la gauche
                {
                    transform.Translate(Vector3.left * hori_speed * Time.deltaTime);
                }
                else //sinon on change de sens car il est arrivé à la limite
                {
                    sens = 1;
                }
            }
            else //direction du boss vers la droite
            {
                if (transform.position.x < 15)//on fait avancer le boss vers la droite
                {
                    transform.Translate(Vector3.right * hori_speed * Time.deltaTime);
                }
                else //sinon on change de sens car il est arrivé à la limite
                {
                    sens = 0;
                }
            }


            if (newStopWatch.ElapsedMilliseconds >= fireSpeed) //si le compteur est supérieur au cooldown de la cadence de tir, on créer 2 bullets + on produit le son de tir
            {
                piste.PlayOneShot(sound);
                Instantiate(bullet, new Vector3((transform.position.x) + 2.0f, transform.position.y, (transform.position.z) - 11.0f), Quaternion.identity);
                Instantiate(bullet, new Vector3((transform.position.x) - 2.0f, transform.position.y, (transform.position.z) - 11.0f), Quaternion.identity);
                
                newStopWatch.Restart();
            }
        }
    }
}
