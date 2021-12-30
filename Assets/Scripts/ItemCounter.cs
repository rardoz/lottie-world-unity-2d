using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCounter : MonoBehaviour
{
	Text counterText;
	public int minItems = 20;
	public int items = 0;
	private int lastItemCount = 0;
	public bool altText;

	void Start()
	{
		counterText = GetComponent<Text>();
	}

	void Update()
	{
		int newMin = minItems - items;
		if (lastItemCount != newMin)
		{
			counterText.text = altText ? $"{items}" : $"{items} / {minItems}";

			if (lastItemCount >= newMin)
			{
				onItemsComplete();
			}

			// must be last
			lastItemCount = newMin;
		}
	}

	protected void onItemsComplete()
	{

	}
}
