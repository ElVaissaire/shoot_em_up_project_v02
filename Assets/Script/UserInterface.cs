using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private Button resume;
    [SerializeField] private Button menuPrincipal;
    
    //Initialise l'�cran de pause comme non actif et associe une fonction au bouton "resume"
    void Start()
    {
        pauseScreen.SetActive(false);
        resume.onClick.AddListener(OnButtonPressed);
        menuPrincipal.onClick.AddListener(OnOtherButtonPressed);
    }

    
    void Update()
    {
        pause();
    }

    
    //Si la touche "echap" est press�e, affiche l'�cran de pause avec ses deux boutons
    void pause()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    //Si le bouton resume est press�, remet le jeu en marche
    //et d�sactive l'�cran de pause
    public void OnButtonPressed()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    //Si le bouton menuPrincipal est press�, remet le jeu en marche
    //d�sactive l'�cran de pause et retourne au menu principal
    public void OnOtherButtonPressed()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }

}
