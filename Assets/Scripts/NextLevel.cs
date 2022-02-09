using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 Next Level will:
 • Go to the chat scene
 • At the end of the chat will go to the next level
 • can use next level for this in both cases
*/
public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public string nextSceneName;

    void OnTriggerEnter2D(Collider2D c2d)
    {
        if (c2d.CompareTag("Player"))
        {
            RobotController.polaroidsEarned = 0;
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
