using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Objet prefab qui permet de changer de scene gr�ce � l'interface unity et la fonction 
//On Click () des boutons

public class SceneChanger : MonoBehaviour
{
	//Charge la sc�ne avec son nom pass� en commentaire
	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	//Quitte l'application
	public void Exit()
	{
		Debug.Log("Merci d'avoir jou� !");
		Application.Quit();
	}
}
