using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    
    [FormerlySerializedAs("theRB")] public Rigidbody2D rb;

    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;
    // For walls thingy
    // Wall climb
    private bool onWall;
    private bool onRightWall;
    private bool onLeftWall;
    private bool wallGrab;
    public int side;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public float groundCheckRadiusSide;
    public LayerMask climbableWalls;
    public float climbSpeed;
    private bool onClimbableWalls;
    // Wall slide
    public bool wallSlide;
    public float slidePower = 1;
    // Wall jump
    public bool canMove;
    public bool wallJumped;
    
    public float hangTime = .2f;
    private float hangCounter;

    public float jumpBufferLength = .5f;
    private float jumpBufferCount;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Run();
        float y = Input.GetAxis("Vertical");

        //Check if is on ground thank to an OverlapCircle
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        
        onLeftWall = Physics2D.OverlapCircle(groundCheckLeft.position, groundCheckRadiusSide, collisionLayers);
        onRightWall = Physics2D.OverlapCircle(groundCheckRight.position, groundCheckRadiusSide, collisionLayers);
        onWall = onLeftWall || onRightWall;
        // If player is on right wall output 1 else -1 -> ternary conditional operator
        side = onRightWall ? 1 : -1;
        onClimbableWalls = Physics2D.OverlapCircle(groundCheckLeft.position, groundCheckRadiusSide, climbableWalls) ||
                           Physics2D.OverlapCircle(groundCheckRight.position, groundCheckRadiusSide, climbableWalls);


        if (onWall && Input.GetButton("Grab") && onClimbableWalls)
        {
            wallGrab = true;
            wallSlide = false;
        }
        
        if (!onWall || Input.GetButtonUp("Grab"))
        {
            wallGrab = false;
            wallSlide = false;
        }

        if (wallGrab && onClimbableWalls)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            float speedModifier = y > 0 ? .35f : .8f;
            rb.velocity = new Vector2(0, y * (climbSpeed * speedModifier));
        }
        else
        {
            rb.gravityScale = 1;
        }

        if (onWall && isGrounded)
        {
            wallSlide = false;
        }

        if (onWall && !isGrounded)
        {
            if (!wallGrab)
            {
                wallSlide = true;
                WallSlide();
            }
        }

        if (isGrounded)
        {
            wallJumped = false;
        }

        // Manage hangtime
        if (isGrounded) {
            hangCounter = hangTime;
        }
        else 
        {
            hangCounter -= Time.deltaTime;
        }
        
        // Manage jump buffer
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCount = jumpBufferLength;
        }
        else
        {
            jumpBufferCount -= Time.deltaTime;
        }

        // Manage jump
        if (jumpBufferCount >= 0 && hangCounter > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpBufferCount = 0;
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
        }
        if (Input.GetButtonDown("Jump") && !isGrounded && onWall)
        {
            WallJump();
        }
    }
    
    private void OnDrawGizmos()
    {
        // Draw an gizmo to represent the OverlapCircle
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckLeft.position, groundCheckRadiusSide);
        Gizmos.DrawWireSphere(groundCheckRight.position, groundCheckRadiusSide);
    }

    private void Run()
    {
        if (!canMove)
            return;
        if (wallGrab)
            return;
        if (!wallJumped)
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);
        else
            rb.velocity = Vector2.Lerp(rb.velocity,
                    new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y), 1 * Time.deltaTime);
    }

    private void WallSlide()
    {
        bool pushingWall = (onRightWall && rb.velocity.x > 0) || (onLeftWall && rb.velocity.x < 0);
        float push = pushingWall ? 0 : rb.velocity.x;
        rb.velocity = new Vector2(push, -slidePower);
    }

    private void WallJump()
    {
        StartCoroutine(DisableMovement(0.1f));
        Vector2 wallDirection = onRightWall ? Vector2.left : Vector2.right;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += (Vector2.up * 1.2f + wallDirection) * jumpForce;
        wallJumped = true;
    }

    IEnumerator DisableMovement(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }
}
