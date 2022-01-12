using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    private PlatformEffector2D effector;

    protected float waitTime;
    public float defaultWaitTime = 0.5f;
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitTime = defaultWaitTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = defaultWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (Input.GetButton("Jump"))
        {
            effector.rotationalOffset = 0f;
        }
    }
}
