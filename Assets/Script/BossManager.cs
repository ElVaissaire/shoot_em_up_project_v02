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


    private void Awake()
    {
        instance = this;
        stopWatch = new Stopwatch();
    }
 // Start is called before the first frame update
    private void Start()
    {
        Invoke("spawnBoss", 9.0f); //apparition du premier boss à 9 secondes
    }

   
    // Update is called once per frame
    void Update()
    {
        if(exists == true)
        {
            bossCanvas.SetActive(true);
        }
        else
        {
            bossCanvas.SetActive(false);
            if(stopWatch.ElapsedMilliseconds >= 30000) //permet de faire spawn le boss 30 secondes après l'avoir vaincu
            {
                spawnBoss();
                stopWatch.Reset();
            }
        }
    }

    void spawnBoss()
    {
        bossInstance = Instantiate(boss, new Vector3(spawnPos.position.x, spawnPos.position.y, spawnPos.position.z + 80.0f), Quaternion.identity);
        exists = true; 
    }

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
