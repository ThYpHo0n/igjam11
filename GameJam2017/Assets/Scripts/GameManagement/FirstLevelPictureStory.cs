using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstLevelPictureStory : MonoBehaviour
{

    [SerializeField]
    private Sprite[] ImageArray;
    [SerializeField]
    private Sprite[] TextArray;
    public GameObject FuckingLaserSight;

    public int SecondToNextImage = 6;
    public GameObject PanelObject;
    public Image LoadingImage_UI;
    public Image StoryImage_UI;

    private const string KeyToContinue = "Press F to Continue";

    private void Awake()
    {
        PanelObject.SetActive(true);
        LoadAllImages();
        FuckingLaserSight.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AbortMissionBriefing();
        }
    }

    void LoadAllImages()
    {
        ImageArray = Resources.LoadAll<Sprite>("LoadingScreenImages/");
        TextArray = Resources.LoadAll<Sprite>("Begintextboxes/");
        LoadingImage_UI.sprite = ImageArray[0];
        StoryImage_UI.sprite = TextArray[0];
    }

    void AbortMissionBriefing()
    {
        FuckingLaserSight.SetActive(true);
        PanelObject.SetActive(false);
        Utility.icewallMove = true;
        Utility.canWalk = true;
        Utility.icewallMove = true;
        AudioManager.instance.PlaySong("Maintheme");
        StopCoroutine("GameStory");
         
    }
    public void StartGameStory()
    {
        StartCoroutine("GameStory");
    }

    IEnumerator GameStory()
    {
        LoadingImage_UI.sprite = ImageArray[0];
        Utility.canWalk = false;
        Utility.icewallMove = false;
        for (int i = 0; i < ImageArray.Length; i++)
        {
            LoadingImage_UI.sprite = ImageArray[i];
            StoryImage_UI.sprite = TextArray[i];
            
            if (LoadingImage_UI.color.a < 1f)
            {
                do
                {
                    LoadingImage_UI.color = Color.Lerp(LoadingImage_UI.color, Color.white, 0.5f * Time.deltaTime);
                    StoryImage_UI.color = Color.Lerp(StoryImage_UI.color, Color.white, 0.5f * Time.deltaTime);
                    yield return new WaitForSeconds(0.001f);
                    if (LoadingImage_UI.color.a > 0.85f)
                    {
                        LoadingImage_UI.color = Color.white;
                        StoryImage_UI.color = Color.white;
                    }
                    Debug.Log(LoadingImage_UI.color.a);
                } while (LoadingImage_UI.color.a < 0.90f);
            }
            yield return new WaitForSeconds(SecondToNextImage);
            do
            {
                LoadingImage_UI.color = Color.Lerp(LoadingImage_UI.color, Color.clear, 0.5f * Time.deltaTime);
                StoryImage_UI.color = Color.Lerp(StoryImage_UI.color, Color.clear, 0.5f * Time.deltaTime);
                yield return new WaitForSeconds(0.001f);
                if (LoadingImage_UI.color.a < 0.25f)
                {
                    LoadingImage_UI.color = Color.clear;
                    StoryImage_UI.color = Color.clear;
                }
                Debug.Log(LoadingImage_UI.color.a);
            } while (LoadingImage_UI.color.a > 0.1f);

        }

        PanelObject.SetActive(false);
        Utility.canWalk = true;
        Utility.icewallMove = true;
        FuckingLaserSight.SetActive(true);
        AudioManager.instance.PlaySong("Maintheme");

    }
};
