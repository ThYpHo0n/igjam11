using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstLevelPictureStory : MonoBehaviour
{

    [SerializeField]
    private Sprite[] ImageArray;


    public int SecondToNextImage = 6;
    public GameObject PanelObject;
    public Image LoadingImage_UI;

    private const string KeyToContinue = "Press F to Continue";

    private void Awake()
    {
        PanelObject.SetActive(true);
        LoadAllImages();
    }

    void LoadAllImages()
    {
        ImageArray = Resources.LoadAll<Sprite>("LoadingScreenImages/");
        LoadingImage_UI.sprite = ImageArray[0];
    }
    public void StartGameStory()
    {
        StartCoroutine("GameStory");
    }

    IEnumerator GameStory()
    {
        LoadingImage_UI.sprite = ImageArray[0];
        for (int i = 0; i < ImageArray.Length; i++)
        {
            Color color = LoadingImage_UI.color;
            color.a = 1;
            LoadingImage_UI.sprite = ImageArray[i];
            LoadingImage_UI.color = color;
            yield return new WaitForSeconds(SecondToNextImage);
            do
            {
                LoadingImage_UI.color = Color.Lerp(LoadingImage_UI.color, Color.clear, 0.5f * Time.deltaTime);
                yield return new WaitForSeconds(0.001f);
                if (LoadingImage_UI.color.a < 0.25f)
                {
                    LoadingImage_UI.color = Color.clear;
                }
                Debug.Log(LoadingImage_UI.color.a);
            } while (LoadingImage_UI.color.a > 0.1f);

        }

        PanelObject.SetActive(false);
    }
};
