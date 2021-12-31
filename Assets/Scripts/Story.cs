using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
	protected string[] storyLines;
	protected int storyLineIndex = 0;

	protected bool shouldPause = false;
	public Text bubbleText;

	public float readingTimer = 0.0f;
	public float readingMiniDuration = 0.1f;
	public float readingTotalTimer = 0.0f;
	public float readingTotalDuration = 1.0f;
	public bool startReading = false;

	public int characterIndex = 0;

	protected bool isDone = false;

	protected string GetStoryLine()
	{
		return storyLines[storyLineIndex];
	}

	protected virtual void OnFinishedStoryLines()
	{
	}

	protected void OnFinishStoryLine()
	{
		shouldPause = true;
	}

	void RenderStoryLine()
	{

		if (startReading)
		{
			string storyLine = GetStoryLine();
			char[] characters = storyLine.ToCharArray();

			char letter = characters[characterIndex];
			bubbleText.text += letter.ToString();

			if (characterIndex == characters.Length - 1)
			{

				characterIndex = 0;
				storyLineIndex++;
				OnFinishStoryLine();
				if (storyLineIndex == storyLines.Length)
				{
					startReading = false;
					storyLineIndex = 0;
					isDone = true;
				}
			}
			else
			{
				characterIndex++;
			}
		}
	}

	void ContinueToNextStoryLine()
	{
		bubbleText.text = "";
		shouldPause = false;
	}


	void Update()
	{
		if (shouldPause)
		{
			if (Input.GetButtonDown("Jump") && !isDone)
			{
				ContinueToNextStoryLine();
			}
			else if (Input.GetButtonUp("Jump") && isDone)
			{
				OnFinishedStoryLines();
			}
			return;
		}

		//this is the letter delay
		readingTimer += Time.deltaTime;
		if (readingTimer >= (Input.GetButton("Jump") ? readingMiniDuration / 2.0f : readingMiniDuration))
		{
			readingTimer = 0.0f;
			RenderStoryLine();
		}
	}
}
