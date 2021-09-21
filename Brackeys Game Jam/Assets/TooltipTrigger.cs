using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject toolTip;
    [SerializeField]
    private GameObject toolTipText;


    private bool isUsed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isUsed)
        {
            isUsed = true;
            Tutorial.Instance.ShowTooltip(toolTip, toolTipText);
        }
    }
}
