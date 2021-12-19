using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bullet : MonoBehaviour
{
    private Vector3 bulletPos;
    [SerializeField] private int bulletSpeed;
    private float upBound;


    // Start is called before the first frame update
    void Start()
    {
        upBound = (float)((float)Screen.height - 25.0f);
    }

    // Update is called once per frame
    void Update()
    {
        bulletPos = Camera.main.WorldToScreenPoint(transform.position);
        bulletMove();
    }

    void bulletMove()
    {
        if(bulletPos.y < upBound)
        {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        if (other.tag == "Enemy")
        {
            Destroy(other);
            Destroy(gameObject);
            GameManager.instance.addScore(100);
        }
    }

}
