using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;

    //AddF
    Vector2 moveInput;
    //walk 
    float move;
    [SerializeField] float speed;
    //jump
    [SerializeField] float jumpForce;
    [SerializeField] bool isjumping;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //move = Input.GetAxis("Horizontal"); //เป็นชุดคีย์ ไปดูในอีดิทโปรเจคเซ็ตติ้ง
        //rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocity.y);
        //New
        moveInput = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2d.AddForce (moveInput*speed);

        if (Input.GetButtonDown("Jump") && !isjumping)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, jumpForce));
            Debug.Log("Jump!"); //โดดได้จริง
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isjumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isjumping = true;
        }
    }
}
