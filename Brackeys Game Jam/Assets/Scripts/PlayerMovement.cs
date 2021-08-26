using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    //Movement
    [Header("Movement")]
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private string[] keyCodes;
    private string[] keyCodesRandomized;

    //Jump
    [Header("Jump")]
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float fallMultiplier;
    [SerializeField]
    private float lightJumpMultiplier;

    //Ground settings
    [Header("Ground")]
    [SerializeField]
    private Transform groundPos;
    [SerializeField]
    private LayerMask groundLayer;

    //Helper Variables for Editor
    [SerializeField]
    private bool isGlitching;

    //Variables
    private float direction;
    private float lastDirection;
    private bool jumpRequest;
    private bool doubleJumpRequest;
    private bool isGrounded;
    
    //Components
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Randomizer randomizer;

    //Delegate and Event
    public delegate void Notify();
    public event Notify SetGlitchedCompleted;

    //State
    public State state { get; set; }
    public enum State
    {
        Normal,
        Glitching,
    }

    //Singleton
    private static PlayerMovement _instance;
    public static PlayerMovement Instance { get { return _instance; } }

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
        keyCodesRandomized = keyCodes;
        state = State.Normal;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        randomizer = new Randomizer();
    }

    void Update()
    {
        switch (state)
        {
            case State.Normal:
                CheckMovement(keyCodes[1], keyCodes[2]);
                JumpRequest(keyCodes[0]);
                break;
            case State.Glitching:
                CheckMovement(keyCodesRandomized[1], keyCodesRandomized[2]);
                JumpRequest(keyCodesRandomized[0]);
                break;
        }
        GroundCheck();
        CheckFacing();
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case State.Normal:
                Jump(keyCodes[0]);
                break;
            case State.Glitching:
                Jump(keyCodesRandomized[0]);
                break;
        }
        Movement();
        //Jump();
    }

    public void SetGlitching()
    {
        state = State.Glitching;
        keyCodesRandomized = randomizer.Randomize(keyCodes);
        SetGlitchedCompleted?.Invoke();
    }
    public void SetNormal()
    {
        state = State.Normal;
    }

    void CheckMovement(string left, string right)
    {
        //direction =isGlitching? Input.GetAxisRaw("Horizontal")*-1: Input.GetAxisRaw("Horizontal");

        if ((Input.GetKey(right) && Input.GetKey(left)) || (!Input.GetKey(right) && !Input.GetKey(left)))
        {
            direction = -0;
        }
        else if (Input.GetKey(right))
        {
            direction = 1;
        }
        else if (Input.GetKey(left))
        {
            direction = -1;
        }
        animator.SetFloat("Horizontal", direction);
    }

    void Movement()
    {
        if (direction != 0)
        {
            transform.position = new Vector2(transform.position.x + (moveSpeed * direction * Time.deltaTime), transform.position.y);
            lastDirection = (direction != 0) ? direction : lastDirection;
        }
    }

    void CheckFacing()
    {
        spriteRenderer.flipX = (lastDirection < 0) ? false : true;
    }

    void JumpRequest(string jump)
    {
        if (Input.GetKeyDown(jump))
        {
            jumpRequest = true;
        }
    }

    void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundPos.position, 0.2f, groundLayer);
        if (isGrounded)
        {
            DoubleJumpCheck();
        }
    }

    void DoubleJumpCheck()
    {
        doubleJumpRequest = true;
    }

    void Jump(string jump)
    {
        if (jumpRequest)
        {
            if (isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpRequest = false;
            }
            else
            {
                if (doubleJumpRequest)
                {
                    rb.velocity = new Vector2(0f, 0f);
                    rb.AddForce(Vector2.up * (jumpForce * 0.8f), ForceMode2D.Impulse);
                    jumpRequest = false;
                    doubleJumpRequest = false;
                }
            }
        }

        if(rb.velocity.y < 0)
        {
            rb.gravityScale = fallMultiplier;
        }
        else if(rb.velocity.y > 0 && !Input.GetKey(jump))
        {
            rb.gravityScale = lightJumpMultiplier;
        }
        else
        {
            rb.gravityScale = 2f;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundPos.position, 0.2f);
    }

}


