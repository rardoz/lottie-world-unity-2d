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

	protected void OnCollected()
	{
		itemCounter.items++;
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D c2d)
	{
		if (itemEnabled && itemCounter && ShouldTriggerEnter2D(c2d))
		{
			if (c2d.CompareTag("Player"))
			{
				OnCollected();
			}
		}
	}

	void OnCollisionEnter2D(Collision2D Col)
	{
		if (itemEnabled && itemCounter && ShouldTrigggerCollisionEnter2D(Col))
		{
			//do stuff
		}
	}
}
