using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : Death
{
    public override bool ShouldKill(Collider2D c2d)
    {
        bool isPlayer = c2d.CompareTag("Player");
        return isPlayer;
    }
}
