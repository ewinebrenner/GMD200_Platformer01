using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6.0f;
    public float jumpSpeed = 12.0f;
    public LayerMask groundLayer;
    public float groundCheckDistance = 1.5f;
    private Rigidbody2D _rb;
    private float _xInput;
    private bool _isJumpPressed; //Has jump been pressed this frame?
    private bool _isGrounded;//Are we on the ground?
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _xInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            _isJumpPressed = true;
        }
    }
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        //Did we hit something?
        if (hit.collider != null)
        {
            _isGrounded = true;
            Debug.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance, Color.green);

        }
        else
        {
            _isGrounded = false;
            Debug.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance, Color.red);
        }

        _rb.velocity = new Vector2(_xInput * moveSpeed, _rb.velocity.y);

        if (_isJumpPressed && _isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed);
        }
        _isJumpPressed = false;

    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    _isGrounded = true;
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    _isGrounded = false;
    //}
}
