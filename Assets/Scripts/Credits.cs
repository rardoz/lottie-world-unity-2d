using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
   bool creditsFinished = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // insure a full press so we don't accidently skip the game over screen when we die
        if (Input.GetButtonUp("Jump") && creditsFinished)
        {
            SceneManager.LoadScene("Main");
        }
    }

    public void CreditFinishAnimationEvent()
    {
        creditsFinished = true;
    }
}
