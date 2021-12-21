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

    public int maxHealthP = 10; //santé max du player
    public int healthP = 2; //santé actuelle du player
    public int score = 0;

    public int maxHealthB = 200; //santé max du boss
    public int healthB = 2; //santé actuelle du boss

    //les santés du boss et du player sont initialisées sur l'interface unity
    //comme une grande partie des objets déclarés


    //On crée un singleton, et s'il existe déjà on détruit l'instance immédiatement
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

    //On initialise chacune des méthodes, on associe une fonction au bouton "retry"
    //et on désactive l'affichage de l'écran de Game Over
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


    //Méthode qui actualise les points de vie du player
    public void TakeDamage(int damageValue)
    {
        healthP = healthP + damageValue;
        if(healthP == 0) //Si le player n'a plus de vie, on lance l'écran de Game Over
        {
            Destroy(player);
            gameOver.SetActive(true);
        }

        healthSlider.value = healthP / (float)maxHealthP; //on actualise l'affichage de la barre de vie
    }

    //Méthode qui actualise les points de vie du boss
    public void BossDamage(int damageValue)
    {
        healthB = healthB + damageValue;
        if(healthB == 0) //si le boss n'a pllus de points de vie
        {
            BossManager.instance.destroyBoss(); //on détruit l'entité "Boss"
            BossManager.instance.exists = false; //on dit qu'il n'existe plus
            BossManager.instance.stopWatch.Start(); //on lance un nouveau compteur pour attendre l'arrivée du prochain boss
            healthB = maxHealthB; //on réinitialise sa vie 
            addScore(1000); //on ajoute au score du joueur plein de points
        }
        bossHealthSlider.value = healthB / (float)maxHealthB; //on actualise l'affichage de la barre de vie
    }

    //Méthode qui ajoute des points de score au joueur et actualise son affichage à l'écran
    public void addScore(int extrasScore)
    {
        score = score + extrasScore;
        scoreText.text = score.ToString();
    }

    //Méthode qui relance la scène actuelle si "retry" est pressé
    public void OnButtonPressed()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
