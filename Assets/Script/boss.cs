using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{

    private int init;
    private int sens;
    private float leftBound;
    private float rightBound;

    // Start is called before the first frame update
    void Start()
    {
        sens = 0;
        rightBound = (float)((float)Screen.width * 75.0 / 100.0);
        leftBound = (float)((float)Screen.width * 35.0 / 100.0);
    }

    // Update is called once per frame
    void Update()
    {
       // if (transform.position.x > BossManager.instance.GetEndPos().x)
        {

        }
    }

    void BossControl()
    {

    }
}
