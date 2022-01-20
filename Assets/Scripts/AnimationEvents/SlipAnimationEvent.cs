using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach to polaroid with animation
public class SlipAnimationEvent : MonoBehaviour
{
    public void SlipAnimationAlertObserver(string message)
    {
        if (message.Equals("SlipFinished"))
        {
            Camera.main.GetComponent<CameraFollow>().followObject.GetComponent<RobotController>().animate.SetBool("Slip", false);
        }
    }
}
