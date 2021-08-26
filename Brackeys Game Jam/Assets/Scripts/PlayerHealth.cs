using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        cam = Camera.main;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 vpPos = cam.WorldToViewportPoint(transform.position);

        bool isVisible = vpPos.x < 1 && vpPos.x > 0 && vpPos.y < 1 && vpPos.y > 0;

        if (!isVisible)
        {
            //spriteRenderer.enabled = false;
            CameraMovement.Instance.Stop();
        }
    }
}
