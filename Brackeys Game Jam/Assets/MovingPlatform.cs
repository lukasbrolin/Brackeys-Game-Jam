using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform[] points;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    public Transform platform;
    private int currentPoint;
    private Vector2 lastPos;
    private bool facingRight;

    [SerializeField]
    private Transform objectTransform;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        platform.position = Vector3.MoveTowards(platform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(platform.position, points[currentPoint].position) < .05f)
        {
            currentPoint++;

            if (currentPoint >= points.Length)
            {
                currentPoint = 0;
            }
        }
        facingRight = (lastPos.x < platform.position.x) ? true : false;
        objectTransform.localScale = (facingRight) ? new Vector3(1,1,1):new Vector3(-1,1,1);

        lastPos = platform.position;
    }
}
