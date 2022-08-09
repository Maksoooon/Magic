using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    [SerializedField]
    public int lives = 5;
    [SerializedField]
    public float speed = 3.0F;
    [SerializedField]
    public float jumpForce = 15.0F;

    new private RigidBody2D rigidBody2D;
    public Animator animator;
    public SpriteRenderer sprite;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRender = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update() {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards();
    }
}
