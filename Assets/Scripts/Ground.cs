using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
	public ShadyAssistant assistant;

	void OnTriggerEnter2D(Collider2D c2d)
	{
		if (c2d.gameObject.tag == "Polaroid")
		{
			assistant.polaroids.Add(c2d.gameObject);
		}
	}
}
