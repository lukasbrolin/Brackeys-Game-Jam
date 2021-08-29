using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finnish : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite winOn, winOff;

    [SerializeField]
    private Text lvlComplete;

    private void Start()
    {
        spriteRenderer.sprite = winOff;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lvlComplete.gameObject.SetActive(true);
            spriteRenderer.sprite = winOn;
            SoundManager.Instance.SetFloat(3);
            LevelManager.Instance.EndLevel();
            LevelManager.Instance.countTime = false;
        }
    }
}
