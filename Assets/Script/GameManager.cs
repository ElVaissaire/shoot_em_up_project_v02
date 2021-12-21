using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider bossHealthSlider;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Button retry;

    public int maxHealthP = 10; //sant� max du player
    public int healthP = 2; //sant� actuelle du player
    public int score = 0;

    public int maxHealthB = 200; //sant� max du boss
    public int healthB = 2; //sant� actuelle du boss

    //les sant�s du boss et du player sont initialis�es sur l'interface unity
    //comme une grande partie des objets d�clar�s


    //On cr�e un singleton, et s'il existe d�j� on d�truit l'instance imm�diatement
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    //On initialise chacune des m�thodes, on associe une fonction au bouton "retry"
    //et on d�sactive l'affichage de l'�cran de Game Over
    void Start()
    {
        retry.onClick.AddListener(OnButtonPressed);
        gameOver.SetActive(false);
        TakeDamage(0);
        BossDamage(0);
        addScore(0);
    }


    void Update()
    {
        
    }


    //M�thode qui actualise les points de vie du player
    public void TakeDamage(int damageValue)
    {
        healthP = healthP + damageValue;
        if(healthP == 0) //Si le player n'a plus de vie, on lance l'�cran de Game Over
        {
            Destroy(player);
            gameOver.SetActive(true);
        }

        healthSlider.value = healthP / (float)maxHealthP; //on actualise l'affichage de la barre de vie
    }

    //M�thode qui actualise les points de vie du boss
    public void BossDamage(int damageValue)
    {
        healthB = healthB + damageValue;
        if(healthB == 0) //si le boss n'a pllus de points de vie
        {
            BossManager.instance.destroyBoss(); //on d�truit l'entit� "Boss"
            BossManager.instance.exists = false; //on dit qu'il n'existe plus
            BossManager.instance.stopWatch.Start(); //on lance un nouveau compteur pour attendre l'arriv�e du prochain boss
            healthB = maxHealthB; //on r�initialise sa vie 
            addScore(1000); //on ajoute au score du joueur plein de points
        }
        bossHealthSlider.value = healthB / (float)maxHealthB; //on actualise l'affichage de la barre de vie
    }

    //M�thode qui ajoute des points de score au joueur et actualise son affichage � l'�cran
    public void addScore(int extrasScore)
    {
        score = score + extrasScore;
        scoreText.text = score.ToString();
    }

    //M�thode qui relance la sc�ne actuelle si "retry" est press�
    public void OnButtonPressed()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
