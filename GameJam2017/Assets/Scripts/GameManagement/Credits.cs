using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour {

    public Image CreditImage;

    public void ShowCreditsScreen()
    {
        if (CreditImage.color.a > 0.5f)
        {
            CreditImage.color = Color.white;
        }
        StartCoroutine("StartCreditsFading");
    }


    IEnumerator StartCreditsFading()
    {
        do
        {
            if (CreditImage.color.a > 0.90f)
            {
                CreditImage.color = Color.white;
            }
            CreditImage.color = Color.Lerp(CreditImage.color, Color.white, 0.5f * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        } while (CreditImage.color.a < 1f);
    }
}
