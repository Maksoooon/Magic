using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : unit
{
    [SerializeField]
    public int lives = 5;
    [SerializeField]
    public float speed = 3.0F;
    [SerializeField]
    public float jumpForce = 15.0F;
    [SerializeField]
    public float circle = 0.09F;

    private bool isGrounded = false;

    private CharacterState State{
        get{return (CharacterState)animator.GetInteger("State");}
        set{animator.SetInteger("State", (int)value);}
    }

    new private Rigidbody2D rb2D;
    public Animator animator;
    public SpriteRenderer sprite;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate() {
        checkIsGrounded();
    }

    private void Update() {
        if(isGrounded)State = CharacterState.Idle;
        if(Input.GetButton("Horizontal")) Run();
        if(isGrounded && Input.GetButtonDown("Jump")) Jump();    
    }

    private void Run() {
        Vector3 direction_horisont = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction_horisont, speed * Time.deltaTime);
        sprite.flipX = direction_horisont.x < 0.0F;

        if(isGrounded)State = CharacterState.Run;
    }

    private void Jump() {

        rb2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        State = CharacterState.Jump;
    }

    private void checkIsGrounded(){
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, circle);
        isGrounded = colliders.Length > 1;

        if(!isGrounded) State = CharacterState.Jump;
    }
}

public enum CharacterState{
    Idle,
    Run,
    Jump,
}