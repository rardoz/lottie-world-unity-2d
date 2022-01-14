using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach to polaroid with animation
public class PolaroidLandingAnimationEvent : MonoBehaviour
{
    public void AlertObservers(string message)
    {
        if (message.Equals("PolaroidLanding"))
        {
            // cool to know: GameObject.FindGameObjectWithTag("ShadyCameraAssistant")
            ShadyAssistant.polaroids.Add(gameObject);
        }
    }
}
