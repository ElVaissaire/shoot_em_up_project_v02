using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Objet prefab qui permet de changer de scene grâce à l'interface unity et la fonction 
//On Click () des boutons

public class SceneChanger : MonoBehaviour
{
	//Charge la scène avec son nom passé en commentaire
	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	//Quitte l'application
	public void Exit()
	{
		Debug.Log("Merci d'avoir joué !");
		Application.Quit();
	}
}
