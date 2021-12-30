using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 Next Level will:
 • Accept a message
 • Will display message in a message bubble
 • Once confirmed / user gets through the messages we can move on to the next level
*/
public class NextLevel : MonoBehaviour
{
	// Start is called before the first frame update
	public string nextSceneName;

	void OnTriggerEnter2D(Collider2D c2d)
	{
		if (c2d.CompareTag("Player"))
		{
			SceneManager.LoadScene(nextSceneName);
		}
	}
}
