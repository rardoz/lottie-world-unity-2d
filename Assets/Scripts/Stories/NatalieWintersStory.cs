using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatalieWintersStory : Story
{
	// Start is called before the first frame update
	void Start()
	{
		storyLines = new string[]{
			"Wow Lottie! You look like a pretty-pretty princess!",
			"I heard you did a great job on your first day as a kinky salad model.",
			"In fact, you did so good the photographer said he would pay you next time!",
			"Oh! Before I go… That shady assistant told me he knows your mother.",
			"So be careful. You wouldn't want these pictures to get into the wrong hands. It would be a PR nightmare!",
			"It's time for your next kinky salad photoshoot! Lets go!"
		};

		bubbleText.text = "";
	}

	protected override void OnFinishedStoryLines()
	{

		TakeoverCanvas.SetActive(true);
		TakeoverCanvas.gameObject.GetComponent<LevelStart>().enabled = true;
	}
}
