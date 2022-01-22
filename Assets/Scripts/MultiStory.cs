using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiStory : MonoBehaviour
{
    public Animator[] StoryTellers;
    public Canvas[] MessageBubbles;

    public StoryObject[] storyLines;

    protected int storyLineIndex = 0;

    protected bool shouldPause = false;

    public GameObject TakeoverCanvas;

    public float readingTimer = 0.0f;
    public float readingMiniDuration = 0.1f;

    public bool startReading = false;

    public int characterIndex = 0;

    public bool isDone = false;

    protected string GetStoryLine()
    {
        return storyLines[storyLineIndex].StoryLine;
    }

    protected Animator GetAnimator()
    {
        return storyLines[storyLineIndex].StoryTeller;
    }

    protected Canvas GetMessageBubble()
    {
        return storyLines[storyLineIndex].MessageBubble;
    }

    protected Text GetBubbleText()
    {
        return GetMessageBubble().GetComponentInChildren<Text>();
    }
    protected void StartWalking()
    {
        GetAnimator().SetFloat("Speed", 1);
    }

    protected void StopWalking()
    {
        GetAnimator().SetFloat("Speed", 0);
    }

    protected void ShowTakeover()
    {

        TakeoverCanvas.SetActive(true);
        TakeoverCanvas.gameObject.GetComponent<LevelStart>().enabled = true;
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
            GetBubbleText().text += letter.ToString();

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
        GetBubbleText().text = "";
        foreach (Canvas bubble in MessageBubbles)
        {
            bubble.gameObject.SetActive(false);
        }
        GetMessageBubble().gameObject.SetActive(true);
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
            else if (Input.GetButtonDown("Jump") && isDone)
            {
                OnFinishedStoryLines();
            }
            return;
        }

        //this is the letter delay
        readingTimer += Time.deltaTime;
        if (readingTimer >= readingMiniDuration / 4.0f || Input.GetButtonUp("Jump"))
        {
            readingTimer = 0.0f;
            RenderStoryLine();
        }
    }
}
