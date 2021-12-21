using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonus : MonoBehaviour
{
    private int speed;
    [SerializeField] private GameObject bulletPlayer;
    [SerializeField] private GameObject bulletBoss;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > HealthBonusManager.instance.GetEndPos().z)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
