using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherAndLottieStory : MultiStory
{
    // Start is called before the first frame update
    void Start()
    {
        Animator firstStoryTeller = StoryTellers[0];
        Animator secondStoryTeller = StoryTellers[1];
        Canvas firstMessageBubble = MessageBubbles[0];
        Canvas secondMessageBubble = MessageBubbles[1];

        storyLines = new StoryObject[]{
            new StoryObject(firstStoryTeller, firstMessageBubble, "Hello 1!"),
            new StoryObject(secondStoryTeller, secondMessageBubble, "Hello 2!"),
            new StoryObject(firstStoryTeller, firstMessageBubble, "Hello 3!"),
            new StoryObject(secondStoryTeller, secondMessageBubble, "Hello 4..."),
            new StoryObject(secondStoryTeller, secondMessageBubble, "mother 5.......")
        };

        GetBubbleText().text = "";
        StartWalking();
    }

    public void MotherStoryAnimationEvent(string message)
    {
        if (message == "Animation1Finished")
        {
            StopWalking();
            startReading = true;
            GetMessageBubble().gameObject.SetActive(true);
        }
    }

    protected override void OnFinishedStoryLines()
    {
        ShowTakeover();
    }
}
