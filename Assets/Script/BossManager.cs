using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossManager : MonoBehaviour
{
    public static BossManager instance = null;

    [SerializeField] private GameObject boss;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private Transform stopPos;
    [SerializeField] private Transform leftPos;
    [SerializeField] private Transform rightPos;


    private void Awake()
    {
        instance = this;

    }
 // Start is called before the first frame update
    private void Start()
    {
        Invoke("spawnBoss", 2.0f);
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnBoss()
    {
        Instantiate(boss, new Vector3(spawnPos.position.x, spawnPos.position.y, spawnPos.position.z + 50.0f), Quaternion.identity);
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
