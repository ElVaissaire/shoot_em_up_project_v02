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

    //On crée un singleton
    private void Awake()
    {
        instance = this;
    }

    //Gère l'apparition des bonus à l'écran
    void Start()
    {
        StartCoroutine(delay());
    }

    
    void Update()
    {
        
    }


    IEnumerator delay()
    {
        while (Application.isPlaying) //tant que le jeu est actif
        {
            spawnRand = Random.Range(-12, 12); //on génère un integer aléatoirement entre -12 et 12 pour l'utiliser en position de spawn en x
            Instantiate(bonus, new Vector3(spawnRand, startPos.position.y, startPos.position.z), Quaternion.identity); //on créer un objet "bonus" à l'écran
            yield return new WaitForSeconds(apparition); //on attend le délai d'apparition avant de recréer un objet "bonus"
        }
    }

    public Vector3 GetEndPos()
    {
        return endPos.position;
    }
}
