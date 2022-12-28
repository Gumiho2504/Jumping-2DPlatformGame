using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
   private Rigidbody2D rb;
    private Animator anim;
    private float dirX = 0f;
    private SpriteRenderer sprite;
    [SerializeField] private float MoveSpeed = 7f;
    [SerializeField] private float JumpPower = 14f;
    private BoxCollider2D coll;  // created for player collider in script
    [SerializeField] private LayerMask jumpableGrond; // created for check grond of ot collidedn with terain
    [SerializeField] private AudioSource jumoSounEffect;
   // amd to input layer name that player collided in to script 
    private enum MovementState { idle,running,jumping,falling}
  
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();   
        sprite = GetComponent<SpriteRenderer>();        //put it to gameOpject name player when game start
    }

    public void click()
    {
        if (IsGrounded()) { jumoSounEffect.Play();
        rb.velocity = new Vector3(rb.velocity.x, JumpPower, 0); }
       
    }
   
    // Update is called once per frame
    private void Update()
    {
       dirX = Input.GetAxis("Horizontal");
       rb.velocity = new Vector2 (dirX *MoveSpeed,rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumoSounEffect.Play();
            rb.velocity = new Vector3(rb.velocity.x, JumpPower, 0);  //when we jump we also can move to left or right

        }
       
        UpdateAnimationUpdate();
    }
    private  void UpdateAnimationUpdate()
    {
        MovementState state;
        if (dirX > 0f)
        {
            sprite.flipX = false; // if move right front of player move to right also
            state = MovementState.running;
        }else if (dirX < 0f)
        {
            sprite.flipX = true; // make player move left and front of player also move to left
            state = MovementState.running;
        }
          else{
            state = MovementState.idle;
        }
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping; // check jumping and falling with velocityb 
        }
        else if (rb.velocity.y < -.1f) {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state); // chang enum to interger
        }
    private bool IsGrounded() //check ground when collider of player is bounded with layerMask of ground(Tertain set layer name ground) 
    {                         //  and put this funtion in to Update funtion when input key space to jump
       return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down,.1f,jumpableGrond);
    }
}
