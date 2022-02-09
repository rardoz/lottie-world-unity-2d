using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlayanneExitStory : Exit
{
    protected override string awaredMessage => "Well the good news is you earned +" + awardAmount + " in extra bonus points!";
    protected override string awaredMessage2 => "And you found " + RobotController.polaroidsEarned + " bad polaroids! Thats " + ((RobotController.polaroidsEarned - minPolaroids) == 0 ? "no" : (RobotController.polaroidsEarned - minPolaroids) + "") + " more than expected!";
    protected override string awaredMessage3 => "This gives you a total of " + (awardAmount + ScoreCounter.totalScore) + "! Now its time for the bad news...";
    protected override string needMoreMessage => "You need " + (minPolaroids - RobotController.polaroidsEarned) + " more photos before we can leave for the show!";

    protected override void SayExtra()
    {
        string[] storyLines = new string[]{
            awaredMessage,
            awaredMessage2,
            awaredMessage3,
            "That shady assistant sold some of the photos to your mother and she is threating to ruin you!",
            "You better stop her before those photos leak! You can do it, Lottie!"
        };
        cam.messageBubble.SetStoryLines(storyLines);
    }

    protected override bool ShouldGoToNextLevelVerify(bool defaultsChecksOk)
    {
        if (base.ShouldGoToNextLevelVerify(defaultsChecksOk))
        {
            shouldWaitForExitAnimation = true;
            permaLocked = true;
            cam.followObject = null;
        }
        return base.ShouldGoToNextLevelVerify(defaultsChecksOk);
    }

    public void SlayanneAlertObserver(string message)
    {
        if (message.Equals("SlayanneExitFinished"))
        {
            NextLevel();
        }
    }
}
