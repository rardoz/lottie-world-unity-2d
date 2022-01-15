using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwayneStory : Story
{
    void Start()
    {
        storyLines = new string[]{
            "Hi Lottie!\r\nWelcome to Lottie Wood!",
            "I set you up with your first real kinky salad photoshoot.",
            "Before you go… I want to mansplain a few things.",
            "Make sure you watch out for cactus and bull horns. Those horns and thorns will sting!",
            "Grab the polaroids before they fall to the ground. You will need to collect at least 10 photos.",
            "Once they fall some shady assistant guy will come and get them.",
            "I don't trust that assistant. He rolled over my foot with his stupid luggage. So be careful.",
            "Don't let the shady assistant collect the photos. We don't want any ugly ones getting to the photographer.",
            "And don't forget to slay kween! Good luck!"
        };

        bubbleText.text = "";
    }

    protected override void OnFinishedStoryLines()
    {
        TakeoverCanvas.SetActive(true);
    }
}
