using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
    Exit should:
    [ ] countdown remaining seconds really fast
    [ ] countdown should make a sound
    [ ] go to the next level if more than 10 polaroids
    [ ] provide messaging with how many polaroids are remaining
    [ ] Provide summary of earnings
    [ ] Leave the scene with lottie (camera should stay in place)
    [ ] Lock the scene when lottie walks into the exit
    [ ] Scene should unlock if we aren't allowed
*/
enum EXIT_MESSAGE_TYPES
{
    NEED_MORE_MESSAGE,
    CUSTOM_MESSAGE
}
public class Exit : LevelStart
{
    public TimerCounter timerCounter;
    public int minPolaroids = 10;

    RobotController rb;

    private float originalX = 0.0f;

    CameraFollow cam;

    Text message;

    bool pendingMessageAcknowledgment = false;

    public int awardAmount = 0;

    protected bool shouldGoToNextLevel = false;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraFollow>();

        message = cam.messageBubble.GetComponentInChildren<Text>();
    }

    void Update()
    {
        if (pendingMessageAcknowledgment)
        {
            if (Input.GetButton("Jump"))
            {
                TurnOffMessageBubble();
            }
        }
        else if (rb != null)
        {
            if (Input.GetButton("Jump") || Input.GetAxis("Horizontal") < 0)
            {
                if (shouldGoToNextLevel)
                {
                    GoToNextLevel();
                }
                else
                if (rb.locked == true)
                {
                    UnlockScene();
                }
            }
        }
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
        TurnOnMessageBubble();
    }

    void TurnOnMessageBubble()
    {
        cam.messageBubble.SetActive(true);
    }

    void TurnOffMessageBubble()
    {
        cam.messageBubble.SetActive(false);
        pendingMessageAcknowledgment = false;
    }

    void UnlockScene()
    {
        if (rb)
        {
            rb.locked = false;
            cam.followObject = rb.gameObject;
        }
        cam.followObjectOffsetX = originalX;
        timerCounter.UnpauseTimer();
        TurnOffMessageBubble();
    }

    void ContinueCurrentLevel()
    {
        timerCounter.PauseTimer();
        SaySomething(EXIT_MESSAGE_TYPES.NEED_MORE_MESSAGE, "You still need stuff...");
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

    void StartNextLevel()
    {
        awardAmount += timerCounter.secondsRemaining * 100;
        CountdownRemainingSeconds();
        if (awardAmount > 0)
        {
            SaySomething(EXIT_MESSAGE_TYPES.CUSTOM_MESSAGE, awaredMessage);
        }
    }

    protected virtual string awaredMessage => "+" + awardAmount + " point bonus!";
    protected virtual string needMoreMessage => "You need " + (minPolaroids - RobotController.polaroidsEarned) + " more pictures before we can have some real food...";

    void SaySomething(EXIT_MESSAGE_TYPES thatSomething, string defaultMessage)
    {
        if (thatSomething == EXIT_MESSAGE_TYPES.NEED_MORE_MESSAGE)
        {
            message.text = needMoreMessage;
        }
        else
        {
            message.text = defaultMessage;
        }
        if (!cam.messageBubble.activeSelf)
        {
            TurnOnMessageBubble();
        }
        pendingMessageAcknowledgment = true;
    }

    void CountdownRemainingSeconds()
    {
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
