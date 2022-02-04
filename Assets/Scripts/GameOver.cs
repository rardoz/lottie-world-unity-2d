using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    bool didPressDown = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // insure a full press so we don't accidently skip the game over screen when we die
        if (Input.GetButtonUp("Jump") && didPressDown)
        {
            SceneManager.LoadScene("C1S1");
        }
        else if (Input.GetButtonDown("Jump"))
        {
            didPressDown = true;
        }
    }
}
