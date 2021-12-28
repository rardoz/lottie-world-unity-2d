using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
	public ScoreCounter scoreCounter;

	public bool shouldDestroy = true;

	public int scoreValue = 100;

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

	protected void AddToScore(int earnings)
	{
		scoreCounter.totalScore += earnings;
		if (shouldDestroy)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D c2d)
	{
		Debug.Log("Polaroid!" + c2d.gameObject.tag);
		if (itemEnabled && scoreCounter && ShouldTriggerEnter2D(c2d))
		{
			if (c2d.CompareTag("Player"))
			{
				AddToScore(scoreValue);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D Col)
	{
		if (itemEnabled && scoreCounter && ShouldTrigggerCollisionEnter2D(Col))
		{
			//do stuff
		}
	}
}
