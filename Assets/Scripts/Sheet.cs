using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Use with SlideTop Animation
public class Sheet : MonoBehaviour
{
	public bool show = false;

	public string animationName = "SlideTop";
	private bool visible = false;
	Animation anim;

	void Start(){
		anim = 	gameObject.GetComponent<Animation>();

		if(show) {
			SlideFromBottom();
		}
	}
    void Update()
    {
		bool returnKeyPressed = Input.GetKeyDown(KeyCode.Return);
		bool anyKeyPressed = Input.GetButton("Jump") || Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0 || returnKeyPressed;

		if(!visible && returnKeyPressed) {
			SlideFromBottom();
		} else if(visible && anyKeyPressed) {
			SlideToBottom();
		}
    }

	void SlideFromBottom() {
		visible = true;
		anim[animationName].speed = 1;
		anim.Play(animationName);
	}

	void SlideToBottom() {
		visible = false;
		anim[animationName].speed = -1;
		anim[animationName].time = anim[animationName].length;
		anim.Play(animationName);
	}
}
