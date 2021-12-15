using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
	private bool shouldKill = false;

  	void Awake()
    {
        //Make Collider2D as trigger
       GetComponent<Collider2D>().isTrigger = true;
    }

	void Update() {
		if(shouldKill) {
			shouldKill = false;
			Destroy(gameObject.transform.parent.gameObject);
		}
	}

    void OnTriggerEnter2D(Collider2D c2d)
    {
        //Destroy the life if Object tagged Player comes in contact with it
        if (c2d.CompareTag("Player"))
        {
			shouldKill = true;
        }
    }
}
