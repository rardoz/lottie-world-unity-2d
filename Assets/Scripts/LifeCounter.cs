using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour
{
    Text counterText;
    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
		string lifeText = "" + Life.totalLives.ToString();
        //Set the current number of coins to display
        if(counterText.text != lifeText )
        {
            counterText.text = "x" + lifeText;
			if(counterText.text == "x0") {
				Life.totalLives = 3;
 				SceneManager.LoadScene("game-over"); //Load scene called Game
			}
        }
    }
}
