using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class boss : MonoBehaviour
{

    //private int init;
    private int sens = 0;
    private Stopwatch stopWatch;

    [SerializeField] private int hori_speed;
    [SerializeField] private int vert_speed;
    [SerializeField] private GameObject bullet;
    //[SerializeField] private AudioClip sound;
    //[SerializeField] private AudioSource piste;
    [SerializeField] private float fireSpeed = 150.0f;


    private void Awake()
    {
        stopWatch = new Stopwatch();
        stopWatch.Start();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BossControl();
        Debug.Log(transform.position);
    }

    void BossControl()
    {
        if(transform.position.z > BossManager.instance.getStopPos().z)
        {
            transform.Translate(Vector3.back * vert_speed * Time.deltaTime);
        }
        /*else
        {
            if (sens == 0 && transform.position.x > BossManager.instance.getLeftPos().x)
            {
                transform.Translate(Vector3.left * hori_speed * Time.deltaTime);
            }
            if (sens == 0 && transform.position.x == BossManager.instance.getLeftPos().x)
            {
                sens = 1;
                Debug.Log("changement de sens");
            }

            if (sens == 1 && transform.position.x < BossManager.instance.getRightPos().x)
            {
                transform.Translate(Vector3.right * hori_speed * Time.deltaTime);
            }
            if (sens == 1 && transform.position.x == BossManager.instance.getRightPos().x)
            {
                sens = 0;
                Debug.Log("changement de sens");
            }
        }*/


        if (stopWatch.ElapsedMilliseconds >= fireSpeed)
        {
            //piste.PlayOneShot(sound);
            Instantiate(bullet, new Vector3((transform.position.x) + 1.0f, transform.position.y, (transform.position.z) - 3.0f), Quaternion.identity);
            Instantiate(bullet, new Vector3((transform.position.x) - 1.0f, transform.position.y, (transform.position.z) - 3.0f), Quaternion.identity);

            stopWatch.Restart();
        }
    }
}
