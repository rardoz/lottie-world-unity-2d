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
            Polaroid p = gameObject.GetComponent<Polaroid>();
            if (p.shouldBeFollowed)
            {
                ShadyAssistant.polaroids.Add(gameObject);
            }
        }
    }
}
