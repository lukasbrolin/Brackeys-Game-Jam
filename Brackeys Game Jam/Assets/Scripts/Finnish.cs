using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finnish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            LevelManager.Instance.EndLevel();
            LevelManager.Instance.countTime = false;
        }
    }

    
}
