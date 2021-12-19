using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landscape : MonoBehaviour
{

    private int speed;
    private float sizeZ;
    // Start is called before the first frame update
    void Start()
    {
        speed = 8;
        sizeZ = LandScapeManager.instance.whole.transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z+sizeZ > LandScapeManager.instance.getEndPosW().z)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
