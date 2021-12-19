using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager instance = null;
    private float spawn;


    [SerializeField] private GameObject boss;
    [SerializeField] private float apparition;



    private void Awake()
    {
        instance = this;

    }
 // Start is called before the first frame update
    private void Start()
    {
       
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }
}
