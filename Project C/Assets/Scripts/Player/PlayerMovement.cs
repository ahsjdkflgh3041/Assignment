using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 4f;
    private float jumpPower = 100f;
    [SerializeField]
    private Transform groundCheck;
    private float groundCheckRange = 0.25f;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private LayerMask boxLayer;
    private Rigidbody2D playerRigidbody;
    private float x;
    [SerializeField]
    private SpriteRenderer playerSprites;

    // Start is called before the first frame update
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (IsGrounded() && GameInputManager.Instance.GetKeyDown("Jump"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (GameInputManager.Instance.GetKey("Left"))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            playerSprites.flipX = true;
        }
        if (GameInputManager.Instance.GetKey("Right"))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            playerSprites.flipX = false;
        }
    }


    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRange, groundLayer) || Physics2D.OverlapCircle(groundCheck.position, groundCheckRange, boxLayer);

    }

    public void Jump()
    {
        playerRigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(groundCheck.position, groundCheckRange);
    }

}
