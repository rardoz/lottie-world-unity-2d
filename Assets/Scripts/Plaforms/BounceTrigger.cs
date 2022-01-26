using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D c2d)
    {
        if (c2d.CompareTag("Boss"))
        {
            Animator bossAnimator = c2d.GetComponent<Animator>();
            bossAnimator.SetBool("Bounce", true);
        }
    }
}
