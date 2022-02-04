using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takeover : LevelStart
{
    public bool shouldGoToNextLevel = false;

    void Start()
    {
        GameObject.FindGameObjectWithTag("BackgroundAudio").GetComponent<AudioSource>().Stop();
    }
    // Update is called once per frame
    void Update()
    {
        if (shouldGoToNextLevel)
        {
            GoToNextLevel();
        }
    }
}
