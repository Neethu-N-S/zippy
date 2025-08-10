using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public float Speed = 5f;
    private bool grounded;
    public float JumpForce=15f;
    private BoxCollider2D boxCollider;

    Vector2 Move;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Move.x, Move.y,0) * Time.deltaTime * Speed;
        if (Move.x>0)
        {
            transform.localScale = new Vector3(4.7f, 4.5f, 1);
        }
        else if (Move.x<0)
        {
            transform.localScale = new Vector3(-4.7f, 4.5f, 1);
        }
        grounded=isgrounded();
    }
    private bool isgrounded()
    {
        RaycastHit2D Hit=Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,0f,Vector2.down,0.1f);
        return Hit.collider!=null;
    }
    public void OnMove(InputValue value)
    {
        Move=value.Get<Vector2>();
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider=GetComponent<BoxCollider2D>();

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded=true;
        }
        if (collision.gameObject.CompareTag("villian"))
        {
            Debug.Log("Player collided with an enemy!");
            
            
            // Handle collision with enemy
        }
    }
    public void OnJump(InputValue value)
    {
        if (grounded)
        {
            Jump();
        } 
    }
    private void Jump()
    {
        rb.linearVelocity=new Vector2(rb.linearVelocity.x,JumpForce);
        grounded=false;
    }


}