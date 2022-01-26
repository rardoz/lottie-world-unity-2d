using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : MonoBehaviour
{
    public Transform playerTransform;
    public RobotController player;
    public bool isFlipped = false;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<RobotController>();
        playerTransform = player.transform;
    }

    public virtual void Update()
    {

    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > playerTransform.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < playerTransform.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }

    }

    public virtual void Attack()
    {

    }
}
