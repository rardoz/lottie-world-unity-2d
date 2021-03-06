using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeProgress : MonoBehaviour
{
    void Reset()
    {
        Life.totalLives = Life.maxLives;
        ScoreCounter.totalScore = 0;
        RobotController.polaroidsEarned = 0;
        transform.localScale = new Vector2(1.0f, transform.localScale.y);
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x <= 0)
        {
            Reset();
            SceneManager.LoadScene("game-over"); //Load scene called Game
        }
        else
        {
            transform.localScale = new Vector2((1.0f * Life.totalLives / Life.maxLives), transform.localScale.y);
            if (transform.localScale.x > 1)
            {
                transform.localScale = new Vector2(1.0f, transform.localScale.y);
            }
        }
    }
}
