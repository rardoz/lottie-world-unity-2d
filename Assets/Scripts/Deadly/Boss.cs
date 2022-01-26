using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public virtual void NextLevel()
    {
        SceneManager.LoadScene("game-over");
    }


    void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(Col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    public virtual void Attack()
    {
        gameObject.GetComponent<Animator>().SetBool("Attack", false);
    }
}
