using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator animator;

    //Helps with fliping the sprite horizontally.
    private SpriteRenderer spriteRenderer;

    [Header("Movement")]
    public float moveSpeed = 5f;
    float horizontalMovement;

    [Header("Jumping")]
    public float jumpSpeed = 10f;
    private bool inAir = true;

    [Header("Ground Check")]
    public Transform groundCheckPosition;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;

    [Header("Attacking")]
    public bool isAttacking = false;

    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {

        rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocity.y);


        //Switch sprite direction with player.
        if (rb.linearVelocityX > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(rb.linearVelocityX < 0)
        {
            spriteRenderer.flipX = true;
        }
        

        //Player animations.
        animator.SetBool("isGrounded", isGrounded());   //Jump animation.
        animator.SetFloat("magnitude", rb.linearVelocity.magnitude);    //Walking animation.


        //Play SFX when player is touching the ground only once after landing from air.
        if (!isGrounded())
        {
            inAir = true;
        }
        if (inAir && isGrounded())
        {
            inAir = false;
            sfxManager.Play("Land");
        }

    }

    public void Move(InputAction.CallbackContext context)
    {

        horizontalMovement = context.ReadValue<Vector2>().x;

    }

    public void Jump(InputAction.CallbackContext context)
    {

        if (isGrounded())
        {
            if (context.performed)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpSpeed);
                //inAir = true;
            }
            //else if (context.canceled)
            //{
            //    rb.linearVelocity = new Vector2(rb.linearVelocityX, rb.linearVelocityY * 0.5f);
            //}
        }
        else //Allows for lighter taps for shorter jumps
        {
            if (context.canceled)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, rb.linearVelocityY * 0.5f);
            }
        }

    }

    //public void Attack(InputAction.CallbackContext context)
    //{
    //    if (context.performed)
    //    {
    //        isAttacking = true;
    //    }
    //    print("Shoot!");
    //}

    private bool isGrounded()
    {

        if (Physics2D.OverlapBox(groundCheckPosition.position, groundCheckSize, 0, groundLayer))
        {

            return true;

        }

        return false;
    }

    private void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPosition.position, groundCheckSize);

    }

}
