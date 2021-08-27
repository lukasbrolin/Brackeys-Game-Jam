using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string startScene;
    public void Play()
    {
        SceneManager.LoadScene(startScene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
