using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public bool shouldDestroy = true;

    public int scoreValue = 100;

    public bool itemEnabled = true;

    public virtual bool ShouldTriggerEnter2D(Collider2D c2d)
    {
        return true;
    }

    public virtual bool ShouldTrigggerCollisionEnter2D(Collision2D Col)
    {
        return true;
    }
    void Awake()
    {
        //Make Collider2D as trigger
        GetComponent<Collider2D>().isTrigger = true;
    }

    protected void AddToScore(int earnings)
    {
        ScoreCounter.totalScore += earnings;
        PointPopUp ppu = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().pointPopUp;
        ppu.gameObject.SetActive(true);
        ppu.ShowPoints(earnings);

        if (shouldDestroy)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        if (itemEnabled && ShouldTriggerEnter2D(c2d))
        {
            if (c2d.CompareTag("Player"))
            {
                AddToScore(scoreValue);
            }
        }
    }
}
