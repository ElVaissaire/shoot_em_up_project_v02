using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Boss : MonoBehaviour
{
    private Vector3 bulletPos;
    [SerializeField] private int bulletSpeed = 10;
    [SerializeField] private GameObject bonus;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), bonus.GetComponent<Collider>(), true);
    }

    // Update is called once per frame
    void Update()
    {
        bulletPos = Camera.main.WorldToScreenPoint(transform.position);
        bulletMove();
        //Debug.Log(bulletPos.z);
    }

    void bulletMove()
    {
        if (bulletPos.y > 0)
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
            Destroy(gameObject);
            GameManager.instance.TakeDamage(-1);
        }
    }
}
