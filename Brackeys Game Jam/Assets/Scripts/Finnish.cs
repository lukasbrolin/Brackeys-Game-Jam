using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finnish : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite winOn, winOff;

    private void Start()
    {
        spriteRenderer.sprite = winOff;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.sprite = winOn;
            SoundManager.Instance.SetFloat(3);
            LevelManager.Instance.EndLevel();
            LevelManager.Instance.countTime = false;
        }
    }
}
