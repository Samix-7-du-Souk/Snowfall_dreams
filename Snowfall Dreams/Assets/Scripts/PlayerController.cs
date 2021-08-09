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
    }
}
