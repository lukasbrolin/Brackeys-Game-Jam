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
    private Text highScore;

    private void Update()
    {
        highScore.text = PlayerPrefs.GetFloat("Game" + "_time").ToString();
    }
    public void Play()
    {
        SceneManager.LoadScene(startScene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
