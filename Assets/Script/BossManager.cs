using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;

public class BossManager : MonoBehaviour
{
    public static BossManager instance = null;

    [SerializeField] public GameObject boss;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private Transform stopPos;
    [SerializeField] private Transform leftPos;
    [SerializeField] private Transform rightPos;
    [SerializeField] private GameObject bossCanvas;

    private GameObject bossInstance;
    public bool exists = false;
    public Stopwatch stopWatch;


    //On initialise un nouveau compteur utilis� pour d�cider
    //du temps �coul� avant l'apparition du boss
    private void Awake()
    {
        instance = this;
        stopWatch = new Stopwatch();
    }
 
    private void Start()
    {
        Invoke("spawnBoss", 9.0f); //apparition du premier boss � 9 secondes
    }

   
    void Update()
    {
        if(exists == true) //si le boss existe � l'�cran
        {
            bossCanvas.SetActive(true); //on affiche la barre de vie du boss
        }
        else
        {
            bossCanvas.SetActive(false); //on d�sactive la barre de vie du boss
            if(stopWatch.ElapsedMilliseconds >= 30000) //permet de faire spawn le boss 30 secondes apr�s l'avoir vaincu
            {
                spawnBoss(); //on refait spawn le boss
                stopWatch.Reset(); //on remet le compteur � 0
            }
        }
    }

    //Cr�er une nouvelle entit� "Boss" � l'�cran
    void spawnBoss()
    {
        bossInstance = Instantiate(boss, new Vector3(spawnPos.position.x, spawnPos.position.y + 1.0f, spawnPos.position.z + 80.0f), Quaternion.identity);
        exists = true; //le boss existe
    }

    //Permet au GameManager de d�truire le boss si ses points de vie sont �gaux � 0
    public void destroyBoss()
    {
        if(exists == true)
        {
            Destroy(bossInstance);
        }
    }

    public Vector3 getStopPos()
    {
        return stopPos.position;
    }

    public Vector3 getLeftPos()
    {
        return leftPos.position;
    }

    public Vector3 getRightPos()
    {
        return rightPos.position;
    }
}
