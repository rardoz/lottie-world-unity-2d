using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
    Exit should:
    [x] countdown remaining seconds really fast
    [ ] countdown should make a sound
    [x] go to the next level if more than 10 polaroids
    [x] provide messaging with how many polaroids are remaining
    [x] Provide summary of earnings
    [ ] Leave the scene with lottie (camera should stay in place)
    [x] Lock the scene when lottie walks into the exit
    [x] Scene should unlock if we aren't allowed
*/

public class Exit : LevelStart
{
    public TimerCounter timerCounter;
    public int minPolaroids = 10;

    protected bool permaLocked = false;

    RobotController rb;

    public bool shouldWaitForExitAnimation = false;

    private float originalX = 0.0f;

    protected CameraFollow cam;


    public int awardAmount = 0;

    protected bool shouldGoToNextLevel = false;

    protected virtual string awaredMessage => "That was fast! You earned +" + awardAmount + " in extra bonus points!";
    protected virtual string awaredMessage2 => "And you found " + RobotController.polaroidsEarned + " bad polaroids! Thats " + ((RobotController.polaroidsEarned - minPolaroids) == 0 ? "no" : (RobotController.polaroidsEarned - minPolaroids) + "") + " more than expected!";
    protected virtual string awaredMessage3 => "This gives you a total of " + (awardAmount + ScoreCounter.totalScore) + "! Now we can book your next gig!";
    protected virtual string needMoreMessage => "You need " + (minPolaroids - RobotController.polaroidsEarned) + " more pictures before we can have some real food...";

    protected virtual void Start()
    {
        cam = Camera.main.GetComponent<CameraFollow>();
        cam.messageBubble.enabled = false;
    }

    protected virtual void Update()
    {
        if (rb != null && cam.messageBubble.isDone)
        {
            if (Input.GetButton("Jump") || Input.GetAxis("Horizontal") < 0)
            {
                if (shouldGoToNextLevel && !shouldWaitForExitAnimation)
                {
                    NextLevel();
                }
                else if (shouldGoToNextLevel && shouldWaitForExitAnimation && gameObject.GetComponent<Animator>().GetBool("Exit") != true)
                {
                    gameObject.GetComponent<Animator>().SetBool("Exit", true);
                    cam.messageBubble.TurnOffMessageBubble();
                }
                if (rb.locked == true)
                {
                    UnlockScene();
                }
            }
            else if (permaLocked && shouldGoToNextLevel && !shouldWaitForExitAnimation)
            {
                NextLevel();
            }
        }
    }

    private void NextLevel()
    {
        Life.totalLives = Life.maxLives;
        RobotController.polaroidsEarned = 0;
        ScoreCounter.totalScore += awardAmount;
        awardAmount = 0;
        GoToNextLevel();
    }

    void LockScene()
    {
        originalX = cam.followObjectOffsetX;
        if (!rb)
        {
            rb = cam.followObject.GetComponent<RobotController>();
        }
        if (rb)
        {
            rb.locked = true;
        }
        cam.followObject = gameObject;
        cam.followObjectOffsetX = -2f;
    }

    protected void UnlockScene()
    {
        if (!permaLocked && cam.messageBubble.isDone)
        {
            if (rb)
            {
                rb.locked = false;
                cam.followObject = rb.gameObject;
            }
            cam.followObjectOffsetX = originalX;
            timerCounter.UnpauseTimer();
            cam.messageBubble.TurnOffMessageBubble();
        }
    }

    void ContinueCurrentLevel()
    {
        timerCounter.PauseTimer();
        SaySomething(needMoreMessage);
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        if (c2d.CompareTag("Player") && c2d.GetComponent<RobotController>().facingLeft)
        {
            StartExit();
        }
    }

    void StartExit()
    {
        LockScene();
        if (ShouldGoToNextLevel())
        {
            StartNextLevel();
        }
        else
        {
            ContinueCurrentLevel();
        }
    }

    void GetBonusPoints()
    {
        awardAmount += timerCounter.secondsRemaining * 100;
        awardAmount += Life.totalLives * 500;
    }

    protected virtual void SayExtra()
    {
    }

    void StartNextLevel()
    {
        ShadyAssistant.polaroids = new ArrayList();
        GetBonusPoints();
        CountdownRemainingSeconds();
        if (awardAmount > 0)
        {
            SaySomething(awaredMessage, awaredMessage2, awaredMessage3);
            SayExtra();
        }
    }

    void SaySomething(string message)
    {

        cam.messageBubble.SetStoryLines(new string[]{
            message
        });
        cam.messageBubble.TurnOnMessageBubble();
    }

    void SaySomething(string message, string message2)
    {
        cam.messageBubble.SetStoryLines(new string[]{
            message,
            message2
        });
        cam.messageBubble.TurnOnMessageBubble();
    }

    void SaySomething(string message, string message2, string message3)
    {
        cam.messageBubble.SetStoryLines(new string[]{
            message,
            message2,
            message3
        });
        cam.messageBubble.TurnOnMessageBubble();
    }

    void CountdownRemainingSeconds()
    {
        GetComponent<AudioSource>().Play();
        timerCounter.FastForward();
    }

    bool MoreThan10Polaroids()
    {
        return RobotController.polaroidsEarned >= minPolaroids;
    }

    protected virtual bool ShouldGoToNextLevelVerify(bool defaultsChecksOk)
    {
        return defaultsChecksOk;
    }

    bool ShouldGoToNextLevel()
    {
        shouldGoToNextLevel = timerCounter.timeIsUp || MoreThan10Polaroids();
        shouldGoToNextLevel = ShouldGoToNextLevelVerify(shouldGoToNextLevel);
        return shouldGoToNextLevel;
    }

}
