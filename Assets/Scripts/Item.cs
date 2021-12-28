using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public ItemCounter itemCounter;
	public bool itemEnabled = true;


	public virtual bool ShouldTriggerEnter2D(Collider2D c2d)
	{
		return true;
	}

	public virtual bool ShouldTrigggerCollisionEnter2D(Collision2D Col)
	{
		return true;
	}
	void Awake()
	{
		//Make Collider2D as trigger
		GetComponent<Collider2D>().isTrigger = true;
	}

	void OnTriggerEnter2D(Collider2D c2d)
	{
		if (ShouldTriggerEnter2D(c2d))
		{
			if (itemEnabled && c2d.CompareTag("Player") && itemCounter)
			{
				itemCounter.items++;
				Destroy(gameObject);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D Col)
	{
		if (ShouldTrigggerCollisionEnter2D(Col))
		{
			//do stuff
		}
	}
}
