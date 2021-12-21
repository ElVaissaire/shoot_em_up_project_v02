using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public static EnemiesManager instance = null;
    private float spawnRand;
   // private int randomPosition;

    [SerializeField] private GameObject enemy;
    [SerializeField] private float apparition;
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPos;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        apparition = 2.0f;
        StartCoroutine(delay());
    }

    IEnumerator delay()
        {
             while (Application.isPlaying)
             {
                if (BossManager.instance.exists == false)
                {
                    spawnRand = Random.Range(-12, 12);
                    Instantiate(enemy, new Vector3(spawnRand, startPos.position.y, startPos.position.z), Quaternion.identity);
                    
                }
                yield return new WaitForSeconds(apparition);
             }
        }
    public Vector3 GetEndPos()
    {
        return endPos.position;
    }

    //barre de vie = slider 
    // nouveau script GameManager
}
