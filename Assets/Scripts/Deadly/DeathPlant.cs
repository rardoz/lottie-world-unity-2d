using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlant : Death
{
   public Blinker blinker;
    void OnTriggerEnter2D(Collider2D c2d)
    {

		// TODO THROTTLE THE FUNCTION!
		bool isPlayer = c2d.CompareTag("Player");

		//Destroy the life if Object tagged Player comes in contact with it
		if ( isPlayer && !blinker.startBlinking)
		{
				//Destroy life
			if(shouldDestroy){
				Destroy(gameObject);
			}
			//Add life to counter
			totalLives--;
			//Test: Print total number of lives
			Debug.Log("You currently have " + Death.totalLives + " lives.");
		}
    }
}
