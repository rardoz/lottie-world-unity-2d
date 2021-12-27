using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public ItemCounter itemCounter;
	public bool itemEnabled = true;
	void Awake()
	{
		//Make Collider2D as trigger
		GetComponent<Collider2D>().isTrigger = true;
	}

	void OnTriggerEnter2D(Collider2D c2d)
	{
		if (itemEnabled && c2d.CompareTag("Player") && itemCounter)
		{
			itemCounter.items++;
			Destroy(gameObject);
		}
	}
}
