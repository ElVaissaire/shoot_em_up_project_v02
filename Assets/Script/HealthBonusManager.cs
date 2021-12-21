using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonusManager : MonoBehaviour
{
    public static HealthBonusManager instance = null;
    private float spawnRand;

    [SerializeField] private GameObject bonus;
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
        StartCoroutine(delay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator delay()
    {
        while (Application.isPlaying)
        {
            spawnRand = Random.Range(-12, 12);
            Instantiate(bonus, new Vector3(spawnRand, startPos.position.y, startPos.position.z), Quaternion.identity);
            yield return new WaitForSeconds(apparition);
        }
    }

    public Vector3 GetEndPos()
    {
        return endPos.position;
    }
}
