using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEditor.SceneManagement;

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
    

    // Start is called before the first frame update
    void Start()
    {
        rightBound = (float)((float)Screen.width * 90.0 / 100.0);
        leftBound = (float)((float)Screen.width * 10.0 / 100.0);
        upBound = (float)((float)Screen.height * 90.0 / 100.0);
        downBound = (float)((float)Screen.height * 10.0 / 100.0);

        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }


    // Update is called once per frame
    void Update()
    {
        screenPos = m_MainCamera.WorldToScreenPoint(transform.position);
        playerControl();
    }
    
    private void Awake()
    {
        stopWatch = new Stopwatch();
        stopWatch.Start();
    }


    void playerControl()
    {
        transform.Translate(Vector3.forward * m_Speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (screenPos.y < upBound)
            {
                transform.Translate(Vector3.forward * m_VerticalSpeed * Time.deltaTime);
            }
            

        }        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (screenPos.x > leftBound)
            {
                transform.Translate(Vector3.left * m_HorizontalSpeed * Time.deltaTime);
            }

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (screenPos.x < rightBound)
                transform.Translate(Vector3.right * m_HorizontalSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (screenPos.y > downBound)
                transform.Translate(Vector3.back * m_VerticalSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.Space))
        {
                if (stopWatch.ElapsedMilliseconds >= fireSpeed)
            {
                piste.PlayOneShot(sound);
                Instantiate(bullet, new Vector3 ((transform.position.x)-1.0f, transform.position.y, (transform.position.z)+3.0f), Quaternion.identity);
                Instantiate(bullet, new Vector3 ((transform.position.x)+1.0f, transform.position.y, (transform.position.z)+3.0f), Quaternion.identity);
              
                stopWatch.Restart();
            }
        }

    }

     void ProcessFire()
    {
        //créer nouveau tag Enemy dans Unity
        // add rigid body et décocher in kinematic (laisser l'un des deux)
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        if(other.tag == "Enemy")
        {
            Destroy(other);
            GameManager.instance.TakeDamage(-1);
        }


       /* if(other.GetComponent<Enemy>())
        {

        }*/
    }
}
