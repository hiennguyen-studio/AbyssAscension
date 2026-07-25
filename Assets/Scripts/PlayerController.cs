using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedMove = 5f;
    [SerializeField] private float jumpForce = 5f;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        HandMovement();
    }
    private void HandMovement()
    {
        float moveInputX = Input.GetAxis("Horizontal");// tạo biến input để lưu giá trị A/D hoặc mũi tên trái/phải
        //float moveInputY = Input.GetAxis("Vertical");// tạo biến input để lưu giá trị W/S hoặc mũi tên lên/xuống
        rb.linearVelocity = new Vector2(moveInputX * speedMove, rb.linearVelocity.y);//thay đổi vận tốc của rigidbody theo input và speedMove
    }
}
