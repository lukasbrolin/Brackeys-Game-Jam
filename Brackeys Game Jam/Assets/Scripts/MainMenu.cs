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

    private float sum;

    private void Update()
    {
        if (PlayerPrefs.GetFloat("Level_1" + "_time") != null)
        {
            sum += PlayerPrefs.GetFloat("Level_1" + "_time");
        }
        else if(PlayerPrefs.GetFloat("Level_2" + "_time") != null)
        {
            sum += PlayerPrefs.GetFloat("Level_2" + "_time");
        }
        else if (PlayerPrefs.GetFloat("Level_3" + "_time") != null)
        {
            sum += PlayerPrefs.GetFloat("Level_3" + "_time");
        }
        highScoreLevel1.text = PlayerPrefs.GetFloat("Level_1" + "_time").ToString();
        highScoreLevel2.text = PlayerPrefs.GetFloat("Level_2" + "_time").ToString();
        highScoreLevel3.text = PlayerPrefs.GetFloat("Level_3" + "_time").ToString();

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
