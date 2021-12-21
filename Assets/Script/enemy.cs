using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private int speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > EnemiesManager.instance.GetEndPos().z)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
            GameManager.instance.TakeDamage(-1); //on perd un point de vie si un ennemi arrive � passer la limite de l'�cran
        }
    }
}
