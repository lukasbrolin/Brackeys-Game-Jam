using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private static CameraMovement _instance;

    public static CameraMovement Instance { get { return _instance; } }

    [SerializeField]
    private float moveSpeed;
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
        if (isMoving)
        {
            moveSpeed += 0.05f * Time.deltaTime;
            transform.position = new Vector3(transform.position.x + (moveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
            Vector3 position = transform.position;
            position.y = Mathf.Clamp(PlayerMovement.Instance.transform.position.y, minHeight, maxHeight);
            //position.x = PlayerMovement.Instance.transform.position.x;
            transform.position = position;
        }
    }

    public void Stop()
    {
        isMoving = false;
    }
}
