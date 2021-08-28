using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchTrigger : MonoBehaviour
{
    [SerializeField]
    private bool hasBeenTriggered;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasBeenTriggered)
        {
            if (collision.tag.Equals("Player"))
            {
                PlayerMovement.Instance.SetGlitching();
                hasBeenTriggered = true;
            }

        }
    }
}
