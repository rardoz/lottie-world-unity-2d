using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Shady Assistant will:

	✅ Come in and out of the frame
	• Come into the scene when a photo has touched the ground
	• Will go towards the photo to pick it up
	• Once it picks it up it will leave the scene
	• Anytime the shady camera assistant gets a polaroid lottie losses a life
	• If lottie touches the camera assistant lottie looses a life
	• If the camera assistant gets hit in the head, it must leave the scene and come back to get the polaroid
	• If the camera assitant gets hit in the head then it cant pick up polaroids or hurt you
	• If the camera assistant gets hit in the head then it nees to blink to indicate that it was hurt
*/

public class ShadyAssistant : Death
{
	// Start is called before the first frame update
	public bool shouldEnterScene = false;
	public bool shouldEnterFromLeft = true;
	public bool shouldExitScene = false;
	Animation anim;
	void Start()
	{
		anim = gameObject.GetComponent<Animation>();
	}

	// Update is called once per frame
	void Update()
	{
		EnterOrLeaveScene();
	}

	void EnterOrLeaveScene()
	{
		if (shouldEnterScene)
		{
			if (shouldEnterFromLeft)
			{
				EnterFromLeft();
			}
			else
			{
				EnterFromRight();
			}
		}
	}

	void EnterFromRight()
	{
		//todo flip the sprite
		anim["ShadyAssistantAnimation"].speed = -1;
		anim.Play("ShadyAssistantAnimation");
		shouldEnterScene = false;
		shouldEnterFromLeft = true;
	}

	void EnterFromLeft()
	{
		anim["ShadyAssistantAnimation"].speed = 1;
		anim.Play("ShadyAssistantAnimation");
		shouldEnterScene = false;
		shouldEnterFromLeft = false;
	}

	void OnTriggerEnter2D(Collider2D c2d)
	{

		bool isPlayer = c2d.CompareTag("Player");
		bool isPhoto = c2d.CompareTag("Polaroid");
		if (isPlayer || isPhoto)
		{
			//Add life to counter
			totalLives--;
			//Test: Print total number of lives
			Debug.Log("You currently have " + Death.totalLives + " lives.");
		}
	}
}
