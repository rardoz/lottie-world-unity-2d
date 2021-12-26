using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePicture : MonoBehaviour
{
	public Photographer photographer;
	public bool whenFacingLeft;
	// Start is called before the first frame update

	// Update is called once per frame

	void Awake()
	{
		//Make Collider2D as trigger
		GetComponent<Collider2D>().isTrigger = true;
	}

	void OnTriggerEnter2D(Collider2D c2d)
	{
		//Destroy the life if Object tagged Player comes in contact with it
		if (c2d.CompareTag("Player") && photographer.player.facingLeft == whenFacingLeft)
		{
			photographer.OnTakePhoto();
			Destroy(gameObject);
		}
	}
}
