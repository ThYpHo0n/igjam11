using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditFading : MonoBehaviour {

    public Image CreditImage;
	// Use this for initialization
	void Start ()
    {
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
