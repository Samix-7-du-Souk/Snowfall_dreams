using UnityEngine;
using System;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    private NewPlayerScript newPlayerScript;

    private void Awake()
    {
        newPlayerScript = new NewPlayerScript();
    }

    private void OnEnable()
    {
        newPlayerScript.Enable();
    }

    private void OnDisable()
    {
        newPlayerScript.Disable();
    }

    public float moveSpeed;
    public float jumpForce;

    private bool isJumping;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;

    private GameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
    }

    void Update()
    {
        //Read mouv value
        float mouvement = newPlayerScript.Land.move.ReadValue<float>();
        // Move as long as you press the button
        horizontalMovement = mouvement * moveSpeed * Time.deltaTime;

        // Check if is on ground and pressed the jump button
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
    }

    void FixedUpdate()
    {
        //Check if is on ground thank to an OverlapCircle
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        
        MovePlayer(horizontalMovement);
    }

    public void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    private void OnDrawGizmos()
    {
        // Draw an gizmo to represent the OverlapCircle
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}