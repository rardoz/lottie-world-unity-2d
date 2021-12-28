﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
	public bool facingLeft = true;
	public int Playerspeed = 10;
	public int PlayerJumpPower = 1250;
	public float moveX;
	public Vector2 jumpHeight;
	int JumpCount = 0;
	public int MaxJumps = 1; //Maximum amount of jumps (i.e. 2 for double jumps)
	void Start()
	{
		gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
	}

	// Update is called once per frame

	void MoveToPositionOverride()
	{
		Vector3 newPos = transform.position;
		newPos.x = 200;
		transform.position = newPos;
		Camera.main.GetComponent<CameraFollow>().speed = 1000;
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Backslash))
		{
			MoveToPositionOverride();
			return;
		}
		else
		{
			moveX = Input.GetAxis("Horizontal");//Gives us of one if we are moving via the arrow keys

			if (moveX != 0)
			{
				PlayerMove();
				Jump();
				//if we are moving left but not facing left flip, and vice versa
				if (moveX > 0 && !facingLeft)
				{
					Flip();
				}
				else if (moveX < 0 && facingLeft)
				{
					Flip();
				}
			}
		}
	}

	void PlayerMove()
	{
		//Physics
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * Playerspeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

	//Jumping Code
	void Jump()
	{
		bool jumpKey = Input.GetButton("Jump"); // or GetButtonDown

		if (jumpKey && JumpCount > 0)
		{
			gameObject.GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
			JumpCount -= 1;
		}
	}

	void Flip()
	{
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D Col)
	{
		if (Col.gameObject.tag == "Ground")
		{
			JumpCount = MaxJumps;
		}
	}

}


