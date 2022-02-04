using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlant : Death
{
    public override void OnTriggerEnter2D(Collider2D c2d)
    {
        base.OnTriggerEnter2D(c2d);
        if (c2d.gameObject.tag == "Player")
        {
            c2d.gameObject.GetComponent<RobotController>().PlayBrushSound();
        }
    }

    void OnTriggerExit2D(Collider2D c2d)
    {
        if (c2d.gameObject.tag == "Player")
        {
            c2d.gameObject.GetComponent<RobotController>().StopBrushSound();
        }
    }
}
