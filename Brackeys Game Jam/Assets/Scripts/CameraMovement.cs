using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private static CameraMovement _instance;

    public static CameraMovement Instance { get { return _instance; } }
    
    [SerializeField]
    private float increasedSpeed;
    [SerializeField]
    private float normalSpeed;
    [SerializeField]
    private float moveSpeed;
    private bool doubleSpeed;
    [SerializeField]
    private float minHeight, maxHeight;
    [SerializeField]
    public Vector3 startPos;
    [SerializeField]
    private Transform farBackground, middleBackground;

    [SerializeField]
    private bool isMoving;

    private float lastXPos;
    private Vector2 lastPos;

    public bool stopFollow;
    public bool centerPlayer;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        startPos = CameraPos();
        transform.position = startPos;
        lastXPos = transform.position.x;
        farBackground.position = new Vector3(transform.position.x, farBackground.position.y,farBackground.position.z);
        middleBackground.position = new Vector3(transform.position.x,middleBackground.position.y,middleBackground.position.z);
    }

    void Update()
    {
        if (!stopFollow)
        {
            DampMove();
            Move();
        }
        BackgroundFollow();
        CenterPlayer();
    }

    void BackgroundFollow()
    {
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);
        farBackground.position = farBackground.position + new Vector3(amountToMove.x, amountToMove.y * 0.6f, 0f);
        middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f;
        lastPos = transform.position;
    }

    void DampMove()
    {
        Vector3 playerPos = PlayerMovement.Instance.transform.position;
        Vector3 playerPosWorld = Camera.main.WorldToViewportPoint(playerPos);
        if (playerPosWorld.x > 0.8f && !doubleSpeed)
        {
            while (moveSpeed <= increasedSpeed)
                moveSpeed += increasedSpeed * Time.deltaTime;
            doubleSpeed = true;
        }
        else if (playerPosWorld.x < 0.8f && doubleSpeed)
        {
            while (moveSpeed >= normalSpeed)
                moveSpeed -= normalSpeed * Time.deltaTime;
            doubleSpeed = false;
        }
    }

    void Move()
    {
        if (isMoving)
        {
            transform.position = new Vector3(transform.position.x + (moveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
            Vector3 position = transform.position;
            position.y = Mathf.Clamp(PlayerMovement.Instance.transform.position.y, minHeight, maxHeight);
            transform.position = position;
        }
    }

    public void CenterPlayer()
    {
        if (centerPlayer)
        {
            Vector3 playerPos = new Vector3(PlayerMovement.Instance.transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, playerPos, moveSpeed * Time.deltaTime);
        }
    }

    public void Stop()
    {
        isMoving = false;
    }

    public void Resume()
    {
        isMoving = true;
    }

    public Vector3 CameraPos()
    {
        return new Vector3(PlayerMovement.Instance.transform.position.x, Mathf.Clamp(PlayerMovement.Instance.transform.position.y, minHeight, maxHeight), transform.position.z);
    }
}
