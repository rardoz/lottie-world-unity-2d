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

public class Mother : Boss
{
    public override void Attack()
    {
        //Debug.Log("TODO");
        base.Attack();
    }
}
