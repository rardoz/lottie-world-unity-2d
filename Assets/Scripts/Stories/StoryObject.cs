using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryObject
{
    public Animator StoryTeller;
    public Canvas MessageBubble;
    public string StoryLine;
    public StoryObject(Animator storyTeller, Canvas messageBubble, string storyLine)
    {
        StoryTeller = storyTeller;
        MessageBubble = messageBubble;
        StoryLine = storyLine;
    }
}