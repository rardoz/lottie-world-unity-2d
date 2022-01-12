using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            SceneManager.LoadScene("C1S1");
        }
    }
}
