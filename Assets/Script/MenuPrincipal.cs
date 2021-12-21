using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{

    [SerializeField] private GameObject Title;

    [SerializeField] private Button buttonGame;
    [SerializeField] private Button buttonCredits;
    [SerializeField] private Button buttonQuit;

    private float posGame;
    private float posCredits;
    private float posQuit;
    private float posHor;
    private float posVertTitle;
    private float posHorTitle;
  
    //On place les objets à l'écran de manière à ce que ça s'adapte à la taille d'écran
    void Start()
    {
        posGame = (float)(((float)Screen.height * 30.0) / 100.0);
        posCredits = (float)(((float)Screen.height * 20.0) / 100.0);
        posQuit = (float)(((float)Screen.height * 10.0) / 100.0);
        posHor = (float)(((float)Screen.width * 80.0) / 100.0);
        posVertTitle = (float)(((float)Screen.height * 90.0) / 100.0);
        posHorTitle = (float)(((float)Screen.width * 50.0) / 100.0);
        buttonGame.transform.position = new Vector3(posHor, posGame, 0);
        buttonCredits.transform.position = new Vector3(posHor, posCredits, 0);
        buttonQuit.transform.position = new Vector3(posHor, posQuit, 0);
        Title.transform.position = new Vector3(posHorTitle, posVertTitle, 0);

    }

    void Update()
    {
        
    }
}
