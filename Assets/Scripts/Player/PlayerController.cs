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
        if(moveInputX < 0) // nhấn A/mũi trên trái, biên InputX sẽ nhận giá trị -1
        {
            transform.localScale = new Vector3(-1, 1, 1);//lật nhân vật sang trái/ mục Scale ở transform sẽ nhận giá trị -1,1,1
        }
        else if(moveInputX > 0)// nhấn D/mũi trên phải, biên InputX sẽ nhận giá trị 1
        {
            transform.localScale = new Vector3(1, 1, 1);//lật nhân vật sang phải/ mục Scale ở transform sẽ nhận giá trị 1,1,1
        }
    }
}
