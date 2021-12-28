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
		transform.localScale = new Vector2(Life.totalLives / 100.0f, transform.localScale.y);
	}
}
