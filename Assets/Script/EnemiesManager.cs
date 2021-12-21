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


    //Cr�ation d'un singleton
    private void Awake()
    {
        instance = this;
    }


    //G�re l'apparition des ennemis � l'�cran
    void Start()
    {
        StartCoroutine(delay());
    }

    IEnumerator delay()
        {
             while (Application.isPlaying) //tant que le jeu est actif
             {
                if (BossManager.instance.exists == false) //si une entit� de boss n'existe pas
                {
                    spawnRand = Random.Range(-12, 12); //g�n�re un integer al�atoire entre -12 et 12, utilis� comme position de spawn en x
                    Instantiate(enemy, new Vector3(spawnRand, startPos.position.y, startPos.position.z), Quaternion.identity);
                    
                }
                yield return new WaitForSeconds(apparition); //apr�s le certain d�lai un nouvel ennemi est cr��
             }
        }
    public Vector3 GetEndPos()
    {
        return endPos.position;
    }

}
