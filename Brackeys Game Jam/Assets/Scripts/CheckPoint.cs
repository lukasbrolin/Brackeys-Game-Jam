using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite cpOn, cpOff;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Match");
            CheckPointManager.Instance.DeactivateCheckpoints();

            spriteRenderer.sprite = cpOn;

            CheckPointManager.Instance.SetSpawnPoint(transform.position);
        }
    }

    public void ResetCheckpoint()
    {
        spriteRenderer.sprite = cpOff;
    }
}
