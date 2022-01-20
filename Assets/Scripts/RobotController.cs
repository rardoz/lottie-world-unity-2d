using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    public bool facingLeft = true;
    public int Playerspeed = 10;
    public int PlayerJumpPower = 1250;
    public static int polaroidsEarned;
    public float moveX;
    public Vector2 jumpHeight;
    int JumpCount = 0;
    public int MaxJumps = 1; //Maximum amount of jumps (i.e. 2 for double jumps)
    public Animator animate;

    private bool isCoroutineExecuting = false;

    public bool locked = false;

    void Start()
    {
        animate = gameObject.GetComponent<Animator>();
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    void Update()
    {
        if (!locked)
        {
            if (!animate.GetBool("Slip"))
            {
                moveX = Input.GetAxis("Horizontal");//Gives us of one if we are moving via the arrow keys
                if (moveX != 0)
                {
                    PlayerMove();

                    //if we are moving left but not facing left flip, and vice versa
                    if (moveX > 0 && !facingLeft)
                    {
                        Flip();
                    }
                    else if (moveX < 0 && facingLeft)
                    {
                        Flip();
                    }
                }
                else
                {
                    animate.SetFloat("Speed", 0);
                }
                Jump();
            }
        }
        else
        {
            animate.SetFloat("Speed", 0);
        }
    }

    void PlayerMove()
    {

        animate.SetFloat("Speed", 1);
        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * Playerspeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    public void ShootAnimation()
    {
        animate.SetFloat("Fire", 1);
        StartCoroutine(ExecuteAfterTime(0.30f));
    }

    //Jumping Code
    void Jump()
    {
        bool jumpKey = Input.GetButton("Jump"); // or GetButtonDown
        if (jumpKey && JumpCount > 0 && gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            animate.SetBool("Jump", true);
            gameObject.GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            JumpCount -= 1;
        }
    }


    IEnumerator ExecuteAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        animate.SetFloat("Fire", 0);
        isCoroutineExecuting = false;
    }

    public void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D Col)
    {
        bool isGround = Col.gameObject.tag == "Ground";
        bool isBarrier = Col.gameObject.tag == "Barrier";

        if (isGround || isBarrier)
        {
            JumpCount = MaxJumps;
            animate.SetBool("Jump", false);
        }
    }
}