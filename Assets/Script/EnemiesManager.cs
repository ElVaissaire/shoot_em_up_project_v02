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


    //Création d'un singleton
    private void Awake()
    {
        instance = this;
    }


    //Gère l'apparition des ennemis à l'écran
    void Start()
    {
        StartCoroutine(delay());
    }

    IEnumerator delay()
        {
             while (Application.isPlaying) //tant que le jeu est actif
             {
                if (BossManager.instance.exists == false) //si une entité de boss n'existe pas
                {
                    spawnRand = Random.Range(-12, 12); //génère un integer aléatoire entre -12 et 12, utilisé comme position de spawn en x
                    Instantiate(enemy, new Vector3(spawnRand, startPos.position.y, startPos.position.z), Quaternion.identity);
                    
                }
                yield return new WaitForSeconds(apparition); //après le certain délai un nouvel ennemi est créé
             }
        }
    public Vector3 GetEndPos()
    {
        return endPos.position;
    }

}
