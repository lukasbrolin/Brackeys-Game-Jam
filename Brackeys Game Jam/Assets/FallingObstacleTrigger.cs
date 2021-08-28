using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacleTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject Obstacle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Obstacle.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Obstacle.GetComponent<FallingObstacle>().isFalling = true;

        }
    }
}
