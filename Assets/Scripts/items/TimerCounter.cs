using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TimerCounter : MonoBehaviour
{
    public int secondsRemaining = 10;
    Text counterText;
    Color originalColor;
    void Start()
    {
        counterText = GetComponent<Text>();
        originalColor = counterText.color;
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        while (secondsRemaining > 0)
        {
            yield return new WaitForSeconds(1.0f);
            secondsRemaining--;
            counterText.text = "" + secondsRemaining;

            if (secondsRemaining < 11 && secondsRemaining > 0)
            {
                StartWarning(secondsRemaining % 2 == 1);
            }
        }
        TimeUp();
    }

    void TimeUp()
    {
        Life.totalLives = Life.maxLives;
        SceneManager.LoadScene("game-over"); //Load scene called Game
    }

    void StartWarning(bool odd)
    {
        counterText.color = odd ? Color.black : originalColor;
    }
}
