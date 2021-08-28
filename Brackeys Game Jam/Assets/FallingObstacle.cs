using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacle : MonoBehaviour
{
    [SerializeField]
    private LayerMask groundLayer;

    private Vector3 lastPos;

    private bool isGrounded;
    public bool isFalling;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        isFalling = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(GroundCheck());
    }

    IEnumerator GroundCheck()
    {
        lastPos = transform.position;
        yield return new WaitForSeconds(0.1f);
        if(lastPos == transform.position)
        {
            isGrounded = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 0.4f), 0.4f, groundLayer);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGrounded && isFalling)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Carrot Hit");
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector2(transform.position.x,transform.position.y - 0.4f), 0.4f);
    }
}
