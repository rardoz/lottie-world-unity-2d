using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
	//Keep track of total picked lives (Since the value is static, it can be accessed at "SC_2Dlife.totalLives" from any script)
	public static int maxLives = 25;
	public static int totalLives = 25;

	void Awake()
	{
		//Make Collider2D as trigger
		GetComponent<Collider2D>().isTrigger = true;
	}

	void OnTriggerEnter2D(Collider2D c2d)
	{
		//Destroy the life if Object tagged Player comes in contact with it
		if (c2d.CompareTag("Player"))
		{
			//Add life to counter
			totalLives++;
			//Destroy life
			Destroy(gameObject);
		}
	}
}
