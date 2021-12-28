using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : Life
{
	public RobotController player;
	public bool shouldDestroy = true;
	public virtual void onDeadlyTriggered(Collider2D c2d)
	{

	}

	void Awake()
	{
		// do nothing override to prevent bug
	}
	public void reloadScene()
	{
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}

	protected void OnTriggerEntered(Collider2D c2d)
	{
		bool isPlayer = c2d.CompareTag("Player");

		//Destroy the life if Object tagged Player comes in contact with it
		if (isPlayer)
		{
			//Destroy life
			if (shouldDestroy)
			{
				Destroy(gameObject);
			}
			//Add life to counter
			totalLives--;
			onDeadlyTriggered(c2d);
		}
	}

	void OnTriggerEnter2D(Collider2D c2d)
	{
		OnTriggerEntered(c2d);
	}
}
