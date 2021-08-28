using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerGlitch : MonoBehaviour
{
    [SerializeField]
    private string[] glitchKeyCodes;
    private string[] selectedKeyCodes;
    [SerializeField]
    [Range(1,3)]
    private int level;
    [SerializeField]
    private TextMeshProUGUI[] keyText;

    private Randomizer randomizer;

    private void Start()
    {
        randomizer = new Randomizer();
        PlayerMovement.Instance.SetGlitchedCompleted += HandleGlitch;
    }

    private void Update()
    {
        if (PlayerMovement.Instance.state == PlayerMovement.State.Glitching)
        {
            switch (level)
            {
                case 1:
                    if (Input.GetKey(selectedKeyCodes[0]))
                    {
                        foreach (TextMeshProUGUI text in keyText)
                        {
                            text.transform.parent.gameObject.SetActive(false);
                            //text.enabled = false;
                        }
                        InvokeNormal();
                    }
                    break;
                case 2:
                    if (Input.GetKey(selectedKeyCodes[0]) && Input.GetKey(selectedKeyCodes[1]))
                    {
                        foreach (TextMeshProUGUI text in keyText)
                        {
                            text.transform.parent.gameObject.SetActive(false);
                            //text.enabled = false;
                        }
                        InvokeNormal();
                    }
                    break;
                case 3:
                    if (Input.GetKey(selectedKeyCodes[0]) && Input.GetKey(selectedKeyCodes[1]) && Input.GetKey(selectedKeyCodes[2]))
                    {
                        foreach (TextMeshProUGUI text in keyText)
                        {
                            text.transform.parent.gameObject.SetActive(false);
                            //text.enabled = false;
                        }
                        InvokeNormal();
                    }
                    break;
            }
        }
    }

    void HandleGlitch()
    {
        selectedKeyCodes = randomizer.Randomize(glitchKeyCodes);
        for (int i = 0; i < level; i++)
        {
            keyText[i].text = selectedKeyCodes[i].ToUpper(); ;
            Debug.Log(keyText[i]);
            //keyText[i].enabled = true;
            keyText[i].transform.parent.gameObject.SetActive(true);
            keyText[i].transform.parent.gameObject.transform.parent.gameObject.SetActive(true);
        }


        Debug.Log("This works");
        //Invoke("InvokeNormal", 5f);
    }



    void InvokeNormal()
    {
        keyText[0].transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
        PlayerMovement.Instance.SetNormal();
    }
}
