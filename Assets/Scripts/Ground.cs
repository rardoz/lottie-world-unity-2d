using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D c2d)
	{
		if (c2d.gameObject.tag == "Polaroid")
		{
			ShadyAssistant.polaroids.Add(c2d.gameObject);
		}
	}
}
