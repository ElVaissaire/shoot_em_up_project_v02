using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Boss : MonoBehaviour
{
    private Vector3 bulletPos;
    [SerializeField] private int bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletPos = Camera.main.WorldToScreenPoint(transform.position);
        bulletMove();
    }

    void bulletMove()
    {
        if (bulletPos.y < EnemiesManager.instance.GetEndPos().z)
        {
            transform.Translate(Vector3.back * bulletSpeed * Time.deltaTime);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        if (other.tag == "Player")
        {
            Destroy(other);
            Destroy(gameObject);
            GameManager.instance.addScore(100);
        }
    }
}
