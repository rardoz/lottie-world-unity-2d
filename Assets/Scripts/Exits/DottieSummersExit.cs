using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DottieSummersExit : Exit
{
    protected override string awaredMessage => "OMG Lottie! So poise... so elegant. You earned +" + awardAmount + " in extra bonus points!";
    protected override string awaredMessage2 => "And you found " + RobotController.polaroidsEarned + " bad polaroids! Thats " + ((RobotController.polaroidsEarned - minPolaroids) == 0 ? "no" : (RobotController.polaroidsEarned - minPolaroids) + "") + " more than expected!";
    protected override string awaredMessage3 => "This gives you a total of " + (awardAmount + ScoreCounter.totalScore) + "! You REALLY ARE a super star now.";
    protected override string needMoreMessage => "You need " + (minPolaroids - RobotController.polaroidsEarned) + " more photos before we can have a ponderosa. I know you can do it!";
}
