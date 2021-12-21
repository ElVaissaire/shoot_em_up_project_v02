using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landscape : MonoBehaviour
{

    private int speed;
    private float sizeZ;
    
    //On instancie un objet "Landscape" à la position du prefab en z
    void Start()
    {
        speed = 8;
        sizeZ = LandScapeManager.instance.whole.transform.localPosition.z;
    }

    //On actualise la position du "Landscape"
    void Update()
    {
        if (transform.position.z+sizeZ > LandScapeManager.instance.getEndPosW().z) //s'il n'a pas encore la limite
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime); //on le fait avancer vers bas
        }
        else //sinon on le détruit
        {
            Destroy(gameObject);
        }
    }

}
