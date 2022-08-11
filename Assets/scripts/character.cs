using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    [SerializeField]
    public int lives = 5;
    [SerializeField]
    public float speed = 3.0F;
    [SerializeField]
    public float jumpForce = 15.0F;

    new private Rigidbody2D rb2D;
    public Animator animator;
    public SpriteRenderer sprite;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update() {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}
