using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedMove = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    private bool isGrounded;
    private Animator animator;
    private Rigidbody2D rb;
    private void Awake()
    {   
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        AnimationUpdate();
    }
    private void Movement()
    {
        float moveInputX = Input.GetAxis("Horizontal");// tạo biến input để lưu giá trị A/D hoặc mũi tên trái/phải
        rb.linearVelocity = new Vector2(moveInputX * speedMove, rb.linearVelocity.y);//thay đổi vận tốc của rigidbody theo input và speedMove
        if(moveInputX < 0) // nhấn A/mũi trên trái, biên InputX sẽ nhận giá trị -1
        {
            transform.localScale = new Vector3(-1, 1, 1);//lật nhân vật sang trái/ mục Scale ở transform sẽ nhận giá trị -1,1,1
        }
        else if(moveInputX > 0)// nhấn D/mũi trên phải, biên InputX sẽ nhận giá trị 1
        {
            transform.localScale = new Vector3(1, 1, 1);//lật nhân vật sang phải/ mục Scale ở transform sẽ nhận giá trị 1,1,1
        }
    }
    private void Jump()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);//thay đổi vận tốc của rigidbody theo input và jumpForce
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer);
    }
    private void AnimationUpdate()
    {
        bool isRunning = Mathf.Abs(rb.linearVelocity.x) > 0.1f;
        bool isJumping = !isGrounded;
        animator.SetBool("isRunning",isRunning);
        animator.SetBool("isJumping",isJumping);
    }
}
