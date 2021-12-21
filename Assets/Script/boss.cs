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


    private void Awake()
    {
        newStopWatch = new Stopwatch();
        newStopWatch.Start();
    }

    // Start is called before the first frame update
    void Start()
    {
        piste = GetComponent<AudioSource>();
        piste.volume = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        BossControl();
        //Debug.Log(newStopWatch.ElapsedMilliseconds);
    }

    void BossControl()
    {
        if (transform.position.z > BossManager.instance.getStopPos().z)
        {
            transform.Translate(Vector3.back * vert_speed * Time.deltaTime);
        }
        

        else
        {
            if(sens == 0) //direction du boss vers la gauche
            {
                if(transform.position.x > -18)
                {
                    transform.Translate(Vector3.left * hori_speed * Time.deltaTime);
                }
                else
                {
                    sens = 1;
                }
            }
            else //direction du boss vers la droite
            {
                if (transform.position.x < 18)
                {
                    transform.Translate(Vector3.right * hori_speed * Time.deltaTime);
                }
                else
                {
                    sens = 0;
                }
            }


            if (newStopWatch.ElapsedMilliseconds >= fireSpeed)
            {
                piste.PlayOneShot(sound);
                Instantiate(bullet, new Vector3((transform.position.x) + 2.0f, transform.position.y, (transform.position.z) - 11.0f), Quaternion.identity);
                Instantiate(bullet, new Vector3((transform.position.x) - 2.0f, transform.position.y, (transform.position.z) - 11.0f), Quaternion.identity);
                
                newStopWatch.Restart();
            }
        }
    }
}
