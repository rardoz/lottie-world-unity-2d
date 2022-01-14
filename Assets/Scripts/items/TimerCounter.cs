using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TimerCounter : MonoBehaviour
{
    public int secondsRemaining = 10;
    public float tickerDelay = 1.0f;

    public float defaultTickerDelay = 1.0f;
    Text counterText;
    Color originalColor;
    public bool timeIsUp;
    public bool pause;
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
            yield return new WaitForSeconds(tickerDelay);
            if (!pause)
            {
                secondsRemaining--;
                counterText.text = "" + secondsRemaining + ": Time";

                if (secondsRemaining < 11 && secondsRemaining > 0)
                {
                    StartWarning(secondsRemaining % 2 == 1);
                }
            }
        }
        TimeUp();
    }

    void TimeUp()
    {
        if (tickerDelay == defaultTickerDelay)
        {
            Life.totalLives = Life.maxLives;
            SceneManager.LoadScene("game-over"); //Load scene called Game
        }
        timeIsUp = true;
    }

    void StartWarning(bool odd)
    {
        counterText.color = odd ? Color.black : originalColor;
    }

    public void PauseTimer()
    {
        pause = true;
        tickerDelay = 0.2f;
    }

    public void FastForward()
    {
        tickerDelay = 0f;
    }

    public void UnpauseTimer()
    {
        tickerDelay = defaultTickerDelay;
        pause = false;
    }
}
