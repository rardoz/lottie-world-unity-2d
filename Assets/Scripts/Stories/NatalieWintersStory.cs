using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatalieWintersStory : Story
{
    // Start is called before the first frame update
    void Start()
    {
        storyLines = new string[]{
            "Wait for me... \r\nNatalie Winters!",
            "You did a great job on your first day as a kinky salad model.",
            "In fact, you did so good the photographer said he would pay you next time!",
            "Before I go… That shady assistant told me he knows your mother.",
            "You wouldn't want these pictures to get into the wrong hands. It would be a PR nightmare!",
            "Collect at least 15 photos from the next kinky salad photoshoot.",
            "And watch out for tumbleweeds! I think there might be bear traps too. Lets go!"
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
