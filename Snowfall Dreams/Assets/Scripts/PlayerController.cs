using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    
    public Rigidbody2D theRB;

    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;
    // For walls thingy
    private bool onWall;
    private bool onRightWall;
    private bool onLeftWall;
    public bool wallGrab;
    public int side;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public float groundCheckRadiusSide;
    public LayerMask climbableWalls;
    
    public float hangTime = .2f;
    private float hangCounter;

    public float jumpBufferLength = .5f;
    private float jumpBufferCount;
    
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);
        
        //Check if is on ground thank to an OverlapCircle
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        
        onLeftWall = Physics2D.OverlapCircle(groundCheckLeft.position, groundCheckRadiusSide, climbableWalls);
        onRightWall = Physics2D.OverlapCircle(groundCheckRight.position, groundCheckRadiusSide, climbableWalls);
        onWall = onLeftWall || onRightWall;
        // If player is on right wall output 1 else -1 -> ternary conditional operator
        side = onRightWall ? 1 : -1;

        if (onWall && Input.GetButton("Grab"))
        {
            wallGrab = true;
        }
        
        if (!onWall || Input.GetButtonUp("Grab"))
        {
            wallGrab = false;
        }

        if (wallGrab)
        {
            theRB.gravityScale = 0;
            theRB.velocity = new Vector2(theRB.velocity.x, 0);
        }
        else
        {
            theRB.gravityScale = 1;
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
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            jumpBufferCount = 0;
        }
        if (Input.GetButtonUp("Jump") && theRB.velocity.y > 0)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, theRB.velocity.y * .5f);
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
}
