using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Sprite will:
	✅ start where you place it
	✅ move a little faster than the player is moving
	✅ face the user
	• only take photos if player gets salad?
	✅ should follow the user
	✅ should always be facing the user
	✅ should dispense photos
	✅ should have Flash animation
	----

	Other notes:

	• Poloaroids should fall like a feather from way up high in the air
	• Once the polaroid is on the groud the assistant will pop out to try to grab it before lottie
*/

public class Photographer : MonoBehaviour
{
	private Transform cameraTransform;
	private Vector3 lastCameraPosition;
	public RobotController player;
	private Vector2 threshold;
	public float speed = 0;
	public Vector2 followOffset;
	private Rigidbody2D rb;
	private Animator animate;
	public Flash FlashSprite;

	private bool flashEnabled;

	//2.6 - 1.35 = 3.3
	private float originalScale = 1.0f;
	private void Start()
	{
		animate = gameObject.GetComponent<Animator>();
		cameraTransform = Camera.main.transform;
		lastCameraPosition = cameraTransform.position;
		originalScale = transform.localScale.x;
		threshold = calculateThreshold();
		rb = player.GetComponent<Rigidbody2D>();
		if (speed == 0)
		{
			speed = player.Playerspeed * 4;
		}
	}

	private void Update()
	{
		PivotSprite();
		Walk();
		if(Input.GetAxis("Horizontal") != 0) {
			animate.SetFloat("Speed", 1);
		} else {
			animate.SetFloat("Speed", 0);
		}
		TakePhoto();
	}

	void PivotSprite()
	{
		if (player.facingLeft && transform.localScale.x > 0)
		{
			Vector3 theScale = transform.localScale;
			theScale.x = -1 * originalScale;
			transform.localScale = theScale;
		}
		else if (!player.facingLeft && transform.localScale.x < 0)
		{
			Vector3 theScale = transform.localScale;
			theScale.x = 1 * originalScale;
			transform.localScale = theScale;
		}
	}

	private Vector3 calculateThreshold()
	{
		Vector2 t = new Vector2(player.transform.position.x, 0);
		t.x -= followOffset.x;
		return t;
	}

	public void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Vector2 border = calculateThreshold();
		Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
	}

	public void OnTakePhoto()
	{
		flashEnabled = true;
		FlashSprite.flashCount = 0;
	}
	private void TakePhoto()
	{
		if (flashEnabled)
		{
			FlashSprite.MakeFlash();
		}
		else if (!FlashSprite.startBlinking)
		{
			flashEnabled = false;
		}
	}

	private void Walk()
	{
		Vector2 follow = player.transform.position;
		float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);

		Vector3 newPosition = transform.position;
		float followOffsetX = followOffset.x;
		bool isFacingLeft = player.facingLeft;
		followOffsetX *= !player.facingLeft ? -1 : 1;
		if (isFacingLeft)
		{
			if (newPosition.x <= follow.x + followOffsetX)
			{
				newPosition.x = follow.x + followOffsetX;
				float moveSpeed = rb.velocity.magnitude > speed ? rb.velocity.magnitude : speed;
				transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
			}
		}
		else
		{
			if (newPosition.x >= follow.x + followOffsetX)
			{
				newPosition.x = follow.x + followOffsetX;
				float moveSpeed = rb.velocity.magnitude > speed ? rb.velocity.magnitude : speed;
				transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
			}
		}
	}


	void OnCollisionEnter2D(Collision2D Col)
	{
		if (Col.gameObject.tag != "PictureTrigger")
		{
			Physics2D.IgnoreCollision(Col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		}
	}
}
