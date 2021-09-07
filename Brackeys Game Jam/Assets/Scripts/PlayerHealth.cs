using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    private SpriteRenderer spriteRenderer;
    public bool alive;

    void Start()
    {
        cam = Camera.main;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 vpPos = cam.WorldToViewportPoint(transform.position);

        bool isVisible = vpPos.x < 1 && vpPos.x > 0;

        if (!isVisible && alive)
        {
            alive = false;
            CameraMovement.Instance.Stop();
            PlayerMovement.Instance.TakeDamageSound();
            LevelManager.Instance.RespawnPlayer();
        }
        if (isVisible)
        {
            alive = true;
        }
    }
}
