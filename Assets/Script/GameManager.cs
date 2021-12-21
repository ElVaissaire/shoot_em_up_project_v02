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

    public int maxHealthP = 10;
    public int healthP = 2;
    public int score = 0;

    public int maxHealthB = 200;
    public int healthB = 2;

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
        BossDamage(0);
        addScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageValue)
    {
        healthP = healthP + damageValue;
        if(healthP == 0)
        {
            Destroy(player);
            gameOver.SetActive(true);
        }

        healthSlider.value = healthP / (float)maxHealthP;
    }

    public void BossDamage(int damageValue)
    {
        healthB = healthB + damageValue;
        if(healthB == 0)
        {
            BossManager.instance.destroyBoss();
            BossManager.instance.exists = false;
            BossManager.instance.stopWatch.Start();
            healthB = maxHealthB;
            addScore(1000);
        }
        bossHealthSlider.value = healthB / (float)maxHealthB;
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
