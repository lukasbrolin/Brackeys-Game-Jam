using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEdge : MonoBehaviour
{
    [SerializeField]
    private FallingObstacle obstacle;
    [FMODUnity.EventRef]
    [SerializeField]
    private string bumpPlayerEvent;
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
        if (!obstacle.isGrounded && obstacle.isFalling)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                FMODUnity.RuntimeManager.PlayOneShot(bumpPlayerEvent);
                PlayerMovement.Instance.TakeDamageSound();
                LevelManager.Instance.RespawnPlayer();
                Debug.Log("Carrot Hit");
                this.gameObject.SetActive(false);
            }
        }
    }
}
