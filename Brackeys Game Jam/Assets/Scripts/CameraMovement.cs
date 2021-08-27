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
    private bool isMoving;

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

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(PlayerMovement.Instance.transform.position.x, Mathf.Clamp(PlayerMovement.Instance.transform.position.y, minHeight, maxHeight),transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        DampMove();
        Move();
    }

    void DampMove()
    {
        Vector3 playerPos = PlayerMovement.Instance.transform.position;
        Vector3 playerPosWorld = Camera.main.WorldToViewportPoint(playerPos);
        Debug.Log(playerPosWorld);
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
            moveSpeed += 0.05f * Time.deltaTime;
            transform.position = new Vector3(transform.position.x + (moveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
            Vector3 position = transform.position;
            position.y = Mathf.Clamp(PlayerMovement.Instance.transform.position.y, minHeight, maxHeight);
            transform.position = position;
        }
    }

    public void Stop()
    {
        isMoving = false;
    }
}
