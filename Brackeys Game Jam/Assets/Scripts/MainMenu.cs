using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string startScene;
    [SerializeField]
    private Text highScoreLevel1;
    [SerializeField]
    private Text highScoreLevel2;
    [SerializeField]
    private Text highScoreLevel3;
    [SerializeField]
    private Text total;

    private float sum;
    private void Start()
    {
        if (PlayerPrefs.GetFloat("Level_1" + "_time") != null)
        {
            sum += PlayerPrefs.GetFloat("Level_1" + "_time");
        }
        else
        {
            sum = 0;
        }
        if (PlayerPrefs.GetFloat("Level_2" + "_time") != null)
        {
            sum += PlayerPrefs.GetFloat("Level_2" + "_time");
        }
        else
        {
            sum = 0;
        }
        if (PlayerPrefs.GetFloat("Level_3" + "_time") != null)
        {
            sum += PlayerPrefs.GetFloat("Level_3" + "_time");
        }
        else
        {
            sum = 0;
        }
    }

    private void Update()
    {
        highScoreLevel1.text = "Highscore Level 1: " + PlayerPrefs.GetFloat("Level_1" + "_time").ToString();
        highScoreLevel2.text = "Highscore Level 2: " + PlayerPrefs.GetFloat("Level_2" + "_time").ToString();
        highScoreLevel3.text = "Highscore Level 3: " + PlayerPrefs.GetFloat("Level_3" + "_time").ToString();
        total.text = "Total time: " + sum.ToString();

    }
    public void Play()
    {
        SceneManager.LoadScene(startScene);
        SoundManager.Instance.SetFloat(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
