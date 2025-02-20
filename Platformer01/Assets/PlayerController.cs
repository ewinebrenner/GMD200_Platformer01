using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public PlayerControllerSettings settings;

    private SpriteRenderer _sprite;
    private Animator _animator;
    private Rigidbody2D _rb;
    private float _xInput;
    private bool _isJumpPressed; //Has jump been pressed this frame?
    private bool _isGrounded;//Are we on the ground?

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }
    void Update()
    {
        _xInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            _isJumpPressed = true;
        }
        _animator.SetBool("OnGround", _isGrounded);
        _animator.SetFloat("MoveSpeed", Mathf.Abs(_xInput));

        //_sprite.flipX = _xInput < 0;

        //Flip left or right
        //If facing left and moving right, flip
        if (_sprite.flipX && _xInput > 0)
        {
            _sprite.flipX = false;
        }
        //If facing right and moving left, flip
        else if (!_sprite.flipX && _xInput < 0)
        {
            _sprite.flipX = true;
        }
    }
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, settings.groundCheckDistance, settings.groundLayer);
        //Did we hit something?
        if (hit.collider != null)
        {
            _isGrounded = true;
            Debug.DrawLine(transform.position, transform.position + Vector3.down * settings.groundCheckDistance, Color.green);

        }
        else
        {
            _isGrounded = false;
            Debug.DrawLine(transform.position, transform.position + Vector3.down * settings.groundCheckDistance, Color.red);
        }

        _rb.velocity = new Vector2(_xInput * settings.moveSpeed, _rb.velocity.y);

        if (_isJumpPressed && _isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, settings.jumpSpeed);
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
