using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menümanager : MonoBehaviour {

    public GameObject CreditCanvas;

    public Image CreditImage;

    private void Start()
    {
        CreditCanvas.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CreditCanvas.SetActive(false);
        }
    }

    public void StartGame(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void ShowCredits()
    {
        CreditCanvas.SetActive(true);
        StartCoroutine("StartFade");
    }


    IEnumerator StartFade()
    {
        Utility.canWalk = false;
        if (CreditImage.color.a > 0.85f)
        {
            Color color = CreditImage.color;
            color.a = 0;
            CreditImage.color = color;
        }
        do
        {
            if (CreditImage.color.a >= 0.99f)
            {
                CreditImage.color = Color.white;
            }
            CreditImage.color = Color.Lerp(CreditImage.color, Color.white, 0.5f * Time.deltaTime);
            yield return new WaitForSeconds(0.001f);
        } while (CreditImage.color.a < 1f);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("MainMenu");
    }
}
