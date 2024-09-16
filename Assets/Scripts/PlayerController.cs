using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D _rb;
	private BoxCollider2D _coll;
	private SpriteRenderer _sprite;
	private Animator _anim;

	[SerializeField] private AudioSource _audioJump;
	[SerializeField] private LayerMask jumpableGround;

	private float dirX;
	[SerializeField] private float moveSpeed = 7f;
	[SerializeField] private float jumpForce = 14f;

	private enum MovementState { idle, running, jumping, falling }

	private void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
		_coll = GetComponent<BoxCollider2D>(); 
		_sprite = GetComponent<SpriteRenderer>();
		_anim = GetComponent<Animator>();
	}

	private void Update()
	{
		dirX = Input.GetAxis("Horizontal");
		_rb.velocity = new Vector2(dirX * moveSpeed, _rb.velocity.y);

		if (Input.GetButtonDown("Jump") && IsGrounded())
		{
			_audioJump.Play();
			_rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
		}

		UpdateAnimationState();
	}

	private void UpdateAnimationState()
	{
		MovementState state;

		if (dirX > 0f)
		{
			state = MovementState.running;
			_sprite.flipX = false;
		}
		else if (dirX < 0f)
		{
			state = MovementState.running;
			_sprite.flipX = true;
		} 
		else
		{
            state = MovementState.idle;
        }
			

		if (_rb.velocity.y > .1f)
		{
            state = MovementState.jumping;
        }	
		else if (_rb.velocity.y < -.1f)
		{
            state = MovementState.falling;
        }
			

		_anim.SetInteger("state", (int)state);
	}

	private bool IsGrounded()
	{
		return Physics2D.BoxCast(_coll.bounds.center, _coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
	}
}
