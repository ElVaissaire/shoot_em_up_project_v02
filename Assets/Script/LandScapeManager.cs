using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class LandScapeManager : MonoBehaviour
{
    public static LandScapeManager instance = null;

    [SerializeField] private Transform startPosW;
    [SerializeField] private Transform endPosW;
    [SerializeField] public GameObject whole;
    [SerializeField] private GameObject instancie1;
    [SerializeField] private GameObject instancie2;
    private bool exists1;
    private bool exists2;

    //On cr�e un singleton
    private void Awake()
    {
        instance = this;
    }

    
    //On instancie deux "Landscape" l'un derri�re l'autre
    //on dit qu'ils existent gr�ce aux variables bool
    void Start()
    {
        startPosW.position = new Vector3(whole.transform.position.x, whole.transform.position.y, 2 * (whole.transform.position.z));
        endPosW.position = new Vector3(whole.transform.position.x, whole.transform.position.y, 0);
        instancie1 = Instantiate(whole, new Vector3(startPosW.position.x, startPosW.position.y, whole.transform.localPosition.z), Quaternion.identity);
        instancie2 = Instantiate(whole, new Vector3(startPosW.position.x, startPosW.position.y, startPosW.position.z + whole.transform.position.z), Quaternion.identity);
        exists1 = true;
        exists2 = true;
    }

    
    void Update()
    {

        if (!exists1 && exists2) //Si le 1er plan n'existe plus et que le 2e existe encore
        {
            //on recr�e le 1er plan derri�re le 2e
            instancie1 = Instantiate(whole, new Vector3(startPosW.position.x, startPosW.position.y, startPosW.position.z + whole.transform.position.z), Quaternion.identity);
            exists1 = true; //on dit que le plan 1 existe � nouveau
        }
        if (!exists2 && exists1) //Si le 2e plan n'existe plus et que le 1er existe encore
        {
            //On recr�e le 2e derri�re le 1er
            instancie2 = Instantiate(whole, new Vector3(startPosW.position.x, startPosW.position.y, startPosW.position.z + whole.transform.position.z), Quaternion.identity);
            exists2 = true; //on dit que le 2e plan existe � nouveau
        }
        else //si les deux plans existent
        {
            if (instancie1 == null) //Si le 1er plan vient � dispara�tre
            {
                exists1 = false; //on dit qu'il n'existe plus
            }
            if (instancie2 == null) //Si le 2e plan vient � dispara�tre
            {
                exists2 = false; //on dit qu'il n'existe plus
            }
        }
    }

    public Vector3 getEndPosW()
    {
        return endPosW.position;
    }
}
