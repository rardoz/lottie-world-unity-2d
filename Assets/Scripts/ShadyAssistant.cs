using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Shady Assistant will:

	✅ Come in and out of the frame
	✅ Come into the scene when a photo has touched the ground
	✅ Will go towards the photo to pick it up
	✅ Once it picks it up it will leave the scene
	✅ Anytime the shady camera assistant gets a polaroid lottie losses a life
	✅ If lottie touches the camera assistant lottie looses a life
	✅ should face the direction its moving towards
	✅ If the camera assistant gets hit in the head, it must leave the scene and come back to get the polaroid
	✅ If the camera assitant gets hit in the head then it cant pick up polaroids or hurt you
	✅ If the camera assistant gets hit in the head then it nees to blink to indicate that it was hurt
*/

public class ShadyAssistant : Death
{
    // Start is called before the first frame update
    public bool shouldEnterFromLeft = true;

    public static ArrayList polaroids = new ArrayList();

    public static int cameraOffset = 10;
    Animation anim;

    public float speed = 0.03f;

    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        blinker = gameObject.GetComponent<Blinker>();
    }

    // Update is called once per frame
    void Update()
    {
        EnterOrLeaveScene();
    }
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void EnterOrLeaveScene()
    {
        if (player)
        {
            Vector2 prevPos = transform.position;
            if (!blinker.startBlinking && polaroids.Count > 0)
            {
                try
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector2((polaroids[0] as GameObject).transform.position.x, transform.position.y), speed);
                }
                catch
                {
                    polaroids.Remove(0);
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector2(player.transform.position.x - cameraOffset, transform.position.y), speed);
            }

            if (transform.position.x - prevPos.x > 0)
            {
                if (transform.localScale.x < 0)
                {
                    Flip();
                }
            }
            else
            {
                if (transform.localScale.x > 0)
                {
                    Flip();
                }
            }
        }
    }

    public override void OnTriggerEnter2D(Collider2D c2d)
    {
        bool isPhoto = c2d.CompareTag("Polaroid");
        if (isPhoto)
        {
            PickUpPolaroid(c2d.gameObject);
        }
    }

    public void PickUpPolaroid(GameObject polaroid)
    {
        polaroids.Remove(polaroid);
        totalLives--;
        Destroy(polaroid.GetComponentInParent<TakePicture>().gameObject);
        GameObject.FindGameObjectWithTag("Player").GetComponent<RobotController>().PlayErrorSound();
    }
}
