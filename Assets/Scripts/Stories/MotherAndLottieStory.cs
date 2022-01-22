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
            new StoryObject(firstStoryTeller, firstMessageBubble, "Mwahahahahaa! I got you now!"),
            new StoryObject(secondStoryTeller, secondMessageBubble, "Hello..."),
            new StoryObject(secondStoryTeller, secondMessageBubble, "mother..."),
            new StoryObject(firstStoryTeller, firstMessageBubble, "A shady looking character sold me some naughty photos of you."),
            new StoryObject(firstStoryTeller, firstMessageBubble, "It cost me a dollar ninty-three for the first few, but then they jacked up the price to a dollar ninty-five cause of inflation."),
            new StoryObject(firstStoryTeller, firstMessageBubble, "But it was worth it because I'm about to ruin you. Say hello to Elton John when you get to gay hell for mommy."),
            new StoryObject(secondStoryTeller, secondMessageBubble, "Elton John isn't dead yet, mom. Sell them. I don't care. I do what I want and I want kinky salad cause I'm a kinky salad MODEL."),
            new StoryObject(firstStoryTeller, firstMessageBubble, "Mwahahahahaa! Prepare to die.")
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
