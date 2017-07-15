using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menümanager : MonoBehaviour {

	public void StartGame(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
