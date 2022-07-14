using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float forceJump = 6f;
	public float speed = 5f;
	Rigidbody2D rgb;
	public LayerMask groundMask;
	Animator anim;
	Vector2 input;
	Vector3 startPosition;
	
	void Awake()
	{
		rgb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void Start()
	{
		startPosition = this.transform.position;
	}

	public void startGame()
	{
		anim.SetBool("IsAlive",false);
		
		this.transform.position = startPosition;
		rgb.velocity = Vector2.zero;
	}

	void FixedUpdate ()
	{
		if(GameManager.sharedInstance.curGameState == gameState.inGame)
		{
			input.x = Input.GetAxisRaw("Horizontal");

			if(input.x != 0)
			{
				run();
			}
			else
			{
				anim.SetBool("IsWalk",false);
			}

			if(Input.GetButtonDown("Jump"))
			{
				jump();
			}

			anim.SetBool("InGrounded",isTouchingGround());
		}
		else
		{
			rgb.velocity = new Vector2(0,rgb.velocity.y);
		}
	}

	void jump()
	{
		if(isTouchingGround())
		{
			rgb.AddForce(Vector2.up * forceJump,ForceMode2D.Impulse);
			anim.SetBool("InGrounded",true);
		}
	}

	void run()
	{
		transform.Translate(input.normalized * speed * Time.fixedDeltaTime);
		anim.SetBool("IsWalk",true);
	}

	bool isTouchingGround()
	{
		if(Physics2D.Raycast(this.transform.position,Vector2.down,0.9f,groundMask))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public void die()
	{
		anim.SetBool("IsAlive",true);
		GameManager.sharedInstance.inGameOver();
	}
}
