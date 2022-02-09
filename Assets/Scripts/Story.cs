using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    public string[] storyLines;
    protected int storyLineIndex = 0;

    protected bool shouldPause = false;
    public Text bubbleText;

    public GameObject TakeoverCanvas;

    public float readingTimer = 0.0f;
    public float readingMiniDuration = 0.1f;

    public bool startReading = false;

    public int characterIndex = 0;

    public bool isDone = false;

    public GameObject messageBubble;

    public Animator storyTellerAnimator;

    protected string GetStoryLine()
    {
        return storyLines[storyLineIndex];
    }

    public void SetStoryLines(string[] newStorylines)
    {
        storyLines = newStorylines;
    }

    public void TurnOffMessageBubble()
    {
        shouldPause = false;
        startReading = false;
        enabled = false;
        storyLineIndex = 0;
        characterIndex = 0;
        isDone = true;
        bubbleText.text = "";
        messageBubble.SetActive(false);
        bubbleText.gameObject.SetActive(false);
    }

    public void TurnOnMessageBubble()
    {
        bubbleText.text = "";
        shouldPause = false;
        enabled = true;
        storyLineIndex = 0;
        characterIndex = 0;
        isDone = false;
        messageBubble.SetActive(true);
        bubbleText.gameObject.SetActive(true);
        startReading = true;
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
        if (Input.GetButtonDown("Fire1"))
        {
            OnFinishedStoryLines();
        }
        else
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
}
