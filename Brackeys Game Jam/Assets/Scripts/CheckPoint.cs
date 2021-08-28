using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [FMODUnity.EventRef]
    [SerializeField]
    private string cpEvent;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite cpOn, cpOff;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.CompareTag("Player"))
        {
            if(spriteRenderer.sprite == cpOff)
            {
                FMODUnity.RuntimeManager.PlayOneShot(cpEvent);
            }
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
