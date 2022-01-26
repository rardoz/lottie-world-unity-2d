using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    Mother should:
    [ ] Hurt lottie by throwing bombs, bottles and poop
    [ ] Need throw animation
    [ ] Mother should start with the same health as lottie
    [ ] Mother should chase lottie (like a fly bouncing left and right around her)
    [ ] When mother is hit with a bow she should fall backwards and blink for a second allowing her to recover
    [ ] Mother should get hurt by the deadly items
    [ ] Once mother is overwhelmed we make lottie jump up and down for joy and the mom should run away with a message bubble
*/

public class MotherOld : Exit
{
    public RobotController player;
    protected static int maxLives = Life.maxLives;
    public static int totalLives = Life.totalLives;
    protected override string awaredMessage => "I can't believe it. You beat me! Here is +" + awardAmount + " in extra bonus points. Grr!";
    protected override string awaredMessage2 => "You may have stopped me from selling those kinky salad photos to fox news today...";
    protected override string awaredMessage3 => "...but this isn't the last of mother. Mwahahahahahahaha!";
    protected override string needMoreMessage => "Don't touch me!";

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private Vector2 threshold;
    public float speed = 0;
    public Vector2 followOffset;
    private Rigidbody2D rigBod;
    private Animator animate;
    private float originalScale = 1.0f;

    protected bool isDefeated = false;
    protected override void Start()
    {
        base.Start();
        animate = gameObject.GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        originalScale = transform.localScale.x;
        threshold = calculateThreshold();
        rigBod = player.GetComponent<Rigidbody2D>();
        if (speed == 0)
        {
            speed = player.Playerspeed;
        }
    }

    protected override void Update()
    {
        if (isDefeated)
        {
            base.Update();
        }
        else
        {
            PivotSprite();
            Walk();
            if (Input.GetAxis("Horizontal") != 0)
            {
                animate.SetFloat("Speed", 1);
            }
            else
            {
                animate.SetFloat("Speed", 0);
            }
        }

    }


    void PivotSprite()
    {
        if (player.facingLeft && transform.localScale.x > 0)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = -1 * originalScale;
            transform.localScale = theScale;
        }
        else if (!player.facingLeft && transform.localScale.x < 0)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = 1 * originalScale;
            transform.localScale = theScale;
        }
    }

    private Vector3 calculateThreshold()
    {
        Vector2 t = new Vector2(player.transform.position.x, 0);
        t.x -= followOffset.x;
        return t;
    }



    private void Walk()
    {
        Vector2 follow = player.transform.position;
        float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);

        Vector3 newPosition = transform.position;
        float followOffsetX = followOffset.x;
        bool isFacingLeft = player.facingLeft;
        followOffsetX *= !player.facingLeft ? -1 : 1;
        if (isFacingLeft)
        {
            if (newPosition.x <= follow.x + followOffsetX)
            {
                newPosition.x = follow.x + followOffsetX;
                float moveSpeed = rigBod.velocity.magnitude > speed ? rigBod.velocity.magnitude : speed;
                transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (newPosition.x >= follow.x + followOffsetX)
            {
                newPosition.x = follow.x + followOffsetX;
                float moveSpeed = rigBod.velocity.magnitude > speed ? rigBod.velocity.magnitude : speed;
                transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
            }
        }
    }


    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 border = calculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }

    protected override bool ShouldGoToNextLevelVerify(bool defaultsChecksOk)
    {
        if (base.ShouldGoToNextLevelVerify(defaultsChecksOk))
        {
            shouldWaitForExitAnimation = true;
            permaLocked = true;
            cam.followObject = null;
        }
        return isDefeated && base.ShouldGoToNextLevelVerify(defaultsChecksOk);
    }

    public void MotherAlertObserver(string message)
    {
        if (message.Equals("MotherExitFinished"))
        {
            GoToNextLevel();
        }
    }

    // void OnCollisionEnter2D(Collision2D Col)
    // {
    //     if (Col.gameObject.tag != "Ground")
    //     {
    //         Physics2D.IgnoreCollision(Col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    //     }
    // }
}
