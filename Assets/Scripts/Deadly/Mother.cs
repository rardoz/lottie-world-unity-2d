using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
    Mother should:
    [ ] Hurt lottie by throwing bombs, bottles and poop
    [ ] Need throw animation
    [x] Mother should start with the same health as lottie
    [x] Mother should chase lottie (like a fly bouncing left and right around her)
    [x] When mother is hit with a bow she should fall backwards and blink for a second allowing her to recover
    [x] Once mother is overwhelmed we make lottie jump up and down for joy and the mom should run away with a message bubble
*/

public class Mother : Boss
{
    public override void Attack()
    {
        //Debug.Log("TODO");
        base.Attack();
    }

    public virtual void NextLevel()
    {
        SceneManager.LoadScene("game-over");
    }
}
