using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : MonoBehaviour
{
	void Awake()
	{
		//Make Collider2D as trigger
		GetComponent<Collider2D>().isTrigger = true;
	}


	void OnTriggerEnter2D(Collider2D c2d)
	{
		//Destroy the life if Object tagged Player comes in contact with it
		if (c2d.CompareTag("Squish"))
		{
			GetComponentInParent<Blinker>().startBlinking = true;
		}
	}
}
