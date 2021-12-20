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

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        startPosW.position = new Vector3(whole.transform.position.x, whole.transform.position.y, 2 * (whole.transform.position.z));
        endPosW.position = new Vector3(whole.transform.position.x, whole.transform.position.y, 0);
        instancie1 = Instantiate(whole, new Vector3(startPosW.position.x, startPosW.position.y, whole.transform.localPosition.z), Quaternion.identity);
        instancie2 = Instantiate(whole, new Vector3(startPosW.position.x, startPosW.position.y, startPosW.position.z + whole.transform.position.z), Quaternion.identity);
        exists1 = true;
        exists2 = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (!exists1 && exists2)
        {
            instancie1 = Instantiate(whole, new Vector3(startPosW.position.x, startPosW.position.y, startPosW.position.z + whole.transform.position.z), Quaternion.identity);
            exists1 = true;
        }
        if (!exists2 && exists1)
        {
            instancie2 = Instantiate(whole, new Vector3(startPosW.position.x, startPosW.position.y, startPosW.position.z + whole.transform.position.z), Quaternion.identity);
            exists2 = true;
        }
        else
        {
            if (instancie1 == null)
            {
                exists1 = false;
            }
            if (instancie2 == null)
            {
                exists2 = false;
            }
        }
    }

    public Vector3 getEndPosW()
    {
        return endPosW.position;
    }
}



/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandScapeManager : MonoBehaviour
{
    public static LandScapeManager instance = null;

    [SerializeField] private Transform startPosPlane;
    [SerializeField] private Transform endPosPlane;
    [SerializeField] public GameObject decor;
    [SerializeField] private GameObject inst1;
    [SerializeField] private GameObject inst2;

    private bool exist1;
    private bool exist2;


    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(inst1);
        startPosPlane.position = new Vector3(decor.transform.position.x, decor.transform.position.y, 2*(decor.transform.position.z));
        endPosPlane.position = new Vector3(decor.transform.position.x, decor.transform.position.y, 0);

        inst1 = Instantiate(decor, new Vector3(startPosPlane.position.x, startPosPlane.position.y, decor.transform.localPosition.z), Quaternion.identity);
        inst2 = Instantiate(decor, new Vector3(startPosPlane.position.x, startPosPlane.position.y, startPosPlane.position.z + decor.transform.position.z), Quaternion.identity);
        exist1 = true;
        exist2 = true;

        Debug.Log(inst1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!exist1 && exist2)
        {
            inst1 = Instantiate(decor, new Vector3(startPosPlane.position.x, startPosPlane.position.y, startPosPlane.position.z + decor.transform.position.z), Quaternion.identity);
            exist1 = true;
        }
        if (!exist2 && exist1)
        {
            inst2 = Instantiate(decor, new Vector3(startPosPlane.position.x, startPosPlane.position.y, startPosPlane.position.z + decor.transform.position.z), Quaternion.identity);
            exist2 = true;
        }
        else
        {
            if(inst1 = null)
            {
                exist1 = false;
            }
            if (inst2 = null)
            {
                exist2 = false;
            }
        }

    }

    public Vector3 getEndPos()
    {
        return endPosPlane.position;
        }
}*/
