using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    private static Tutorial _instance;
    public static Tutorial Instance { get { return _instance; } }

    [SerializeField]
    private GameObject canvas;

    public bool stop;
    public GameObject go;

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

    public void Pause()
    {
        Time.timeScale = 0;
    }

    void Unpause()
    {
        Time.timeScale = 1;
    }

    public void ShowTooltip(GameObject toolTip, GameObject toolTipText)
    {
        Pause();
        toolTip.SetActive(true);
        toolTipText.SetActive(true);
        canvas.SetActive(true);
        StartCoroutine(WaitForAction(toolTip, toolTipText));
    }

    IEnumerator WaitForAction(GameObject toolTip,GameObject toolTipText)
    {
        yield return new WaitUntil(new System.Func<bool>(() => Input.GetKeyDown(KeyCode.P)));
        Unpause();
        toolTip.SetActive(false);
        toolTipText.SetActive(false);
        canvas.SetActive(false);
    }


}
