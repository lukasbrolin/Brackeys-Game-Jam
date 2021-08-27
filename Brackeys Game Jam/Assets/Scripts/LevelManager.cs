using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    private static LevelManager _instance;

    public static LevelManager Instance { get { return _instance; } }

    public float waitToRespawn;

    public string levelToLoad;

    public float timeInLevel;

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
        timeInLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeInLevel += Time.deltaTime;
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

        yield return new WaitForSeconds(1.5f);


    }
}
