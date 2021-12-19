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
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Button retry;

    public int maxHealth = 10;
    public int health = 2;
    public int score = 0;
    

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

    // Start is called before the first frame update
    void Start()
    {
        retry.onClick.AddListener(OnButtonPressed);
        gameOver.SetActive(false);
        TakeDamage(0);
        addScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageValue)
    {
        health = health + damageValue;
        if(health == 0)
        {
            Destroy(player);
            gameOver.SetActive(true);
        }

        healthSlider.value = health / (float)maxHealth;
    }

    public void addScore(int extrasScore)
    {
        score = score + extrasScore;
        scoreText.text = score.ToString();
    }

    public void OnButtonPressed()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
