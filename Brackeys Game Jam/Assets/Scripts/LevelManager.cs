using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    private static LevelManager _instance;
    public static LevelManager Instance { get { return _instance; } }

    public float waitToRespawn;
    public string levelToLoad;
    public float timeInLevel;

    public bool countTime;

    [SerializeField]
    private Text counter;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        countTime = true;
        timeInLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (countTime)
        {
            timeInLevel += Time.deltaTime;
            counter.text = Mathf.Abs(timeInLevel).ToString();
        }
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }
    private IEnumerator RespawnCo()
    {
        

        PlayerMovement.Instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(waitToRespawn);

        PlayerMovement.Instance.gameObject.SetActive(true);

        PlayerMovement.Instance.transform.position = CheckPointManager.Instance.spawnPoint;

        CameraMovement.Instance.transform.position = CameraMovement.Instance.CameraPos();

        CameraMovement.Instance.Resume();

        SoundManager.Instance.SetFloat(4);

    }

    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }

    public IEnumerator EndLevelCo()
    {
        PlayerMovement.Instance.stopInput = true;

        CameraMovement.Instance.stopFollow = true;

        CameraMovement.Instance.centerPlayer = true;

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene(levelToLoad);
        if (levelToLoad.Equals("Main_Menu"))
        {
            SoundManager.Instance.SetFloat(0);
        }
        else
        {
            SoundManager.Instance.SetFloat(1);
        }
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_time"))
        {
            if (timeInLevel < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_time"))
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
            }
        }
        else
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
        }

    }
}
