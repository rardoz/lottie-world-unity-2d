using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
	Polaroid will:

	• shoot up in the air and fall down like a feather
	• should alow to rest on the ground or go past it
	• should go past the ground by default
	•

*/
public class Polaroid : Score
{
    public bool shouldBeFollowed = true;
    public override bool ShouldTriggerEnter2D(Collider2D c2d)
    {
        if (c2d.gameObject.tag == "ShadyCameraAssistant")
        {
            ShadyAssistant.polaroids.Remove(gameObject);
            Destroy(gameObject);
        }
        else if (c2d.gameObject.tag == "Player")
        {
            ShadyAssistant.polaroids.Remove(gameObject);
            Destroy(gameObject);
            RobotController.polaroidsEarned++;
        }
        return true;
    }
}
