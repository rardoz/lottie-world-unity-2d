using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeProgress : MonoBehaviour
{

	// Update is called once per frame
	void Update()
	{
		if (transform.localScale.x <= 0)
		{
			SceneManager.LoadScene("game-over"); //Load scene called Game
		}
		else
		{
			transform.localScale = new Vector2((1.0f * Life.totalLives / Life.maxLives), transform.localScale.y);
		}
	}
}
