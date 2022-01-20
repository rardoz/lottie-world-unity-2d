using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Death
{
    public override bool ShouldKill(Collider2D c2d)
    {
        bool isPlayer = c2d.CompareTag("Player");
        return isPlayer;
    }

    public override void onDeadlyTriggered(Collider2D c2d)
    {
        Camera.main.GetComponent<CameraFollow>().followObject.GetComponent<RobotController>().animate.SetBool("Slip", true);
    }
}
