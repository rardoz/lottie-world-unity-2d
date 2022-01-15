using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach to polaroid with animation
public class StoryTellerWalkAnimationEvent : MonoBehaviour
{
    public void AlertObservers(string message)
    {
        if (message.Equals("EndStoryTellerWalk"))
        {
            // cool to know: GameObject.FindGameObjectWithTag("ShadyCameraAssistant")
            GameObject.FindGameObjectWithTag("StoryTeller").GetComponent<Animator>().SetFloat("Speed", 0);
        }

        if (message.Equals("StartStoryTellerWalk"))
        {
            // cool to know: GameObject.FindGameObjectWithTag("ShadyCameraAssistant")
            GameObject.FindGameObjectWithTag("StoryTeller").GetComponent<Animator>().SetFloat("Speed", 1);
        }
    }
}
