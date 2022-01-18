using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DottieSummersStory : Story
{
    // Start is called before the first frame update
    void Start()
    {
        storyLines = new string[]{
            "Wow... look at that sunset!",
            "Lets fill a tub with all that money. We can sip on seltzer water and pluck each others back hairs.",
            "Oh wait... I totally spaced. You have a big photoshoot tonight! The biggest yet!",
            "You will need to collect at least 20 photos this time.",
            "Then it's time for the grand premiere of your new song, Kinky Salad Model.",
            "I hear SLAYANNE is opening for you! I'm so excited! See you at the show! Bye..."
        };

        bubbleText.text = "";
        storyTellerAnimator.SetFloat("Speed", 1);
    }

    protected override void OnFinishedStoryLines()
    {

        TakeoverCanvas.SetActive(true);
        TakeoverCanvas.gameObject.GetComponent<LevelStart>().enabled = true;
    }
}
