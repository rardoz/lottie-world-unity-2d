using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{

	public float spriteBlinkingTimer = 0.0f;
	public float spriteBlinkingMiniDuration = 0.1f;
	public float spriteBlinkingTotalTimer = 0.0f;
	public float spriteBlinkingTotalDuration = 1.0f;
	public bool startBlinking = false;

	//includes on and off
	public int maxFlashes = 2;

	public int flashCount = 0;

	public void MakeFlash()
	{
		SpriteRenderer renderer = this.gameObject.GetComponent<SpriteRenderer>();

		spriteBlinkingTotalTimer += Time.deltaTime;
		if (flashCount >= maxFlashes || spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
		{
			startBlinking = false;
			spriteBlinkingTotalTimer = 0.0f;
			renderer.enabled = false;
			return;
		}

		spriteBlinkingTimer += Time.deltaTime;
		if (flashCount < maxFlashes && spriteBlinkingTimer >= spriteBlinkingMiniDuration)
		{
			spriteBlinkingTimer = 0.0f;
			if (renderer.enabled == true)
			{
				renderer.enabled = false;
			}
			else
			{
				renderer.enabled = true;
			}
			flashCount++;
		}
	}
}
