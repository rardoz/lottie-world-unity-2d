using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife : MonoBehaviour
{
    //Keep track of total picked lives (Since the value is static, it can be accessed at "SC_2Dlife.totalLives" from any script)
    public static int maxLives = 10;
    public static int totalLives = 10;

    public static int pointValue = 100000;

    public int incriment = 1;

    public RobotController player;

    public bool infinitLives = false;

    public GameObject healthBar;
    protected Blinker blinker;
    void Awake()
    {
        player = player ?? Camera.main.GetComponent<CameraFollow>().followObject.GetComponent<RobotController>();
        blinker = gameObject.GetComponentInChildren<Blinker>();
    }

    void Update()
    {
        if (healthBar.activeSelf == false && blinker.startBlinking)
        {
            healthBar.SetActive(blinker.startBlinking);
        }
        else if (healthBar.activeSelf && !blinker.startBlinking)
        {
            healthBar.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        //Destroy the life if Object tagged Player comes in contact with it
        if (c2d.CompareTag("Weapon") && !blinker.startBlinking)
        {
            blinker.startBlinking = true;
            //Add life to counter
            totalLives -= incriment;
            ScoreCounter.totalScore += pointValue;
        }
    }
}
