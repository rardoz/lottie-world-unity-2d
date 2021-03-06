using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelStart : MonoBehaviour
{
    public int chapter = 1;
    public int scene = 1;

    public string identifier = "";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            GoToNextLevel();
        }
    }

    protected void GoToNextLevel()
    {
        string subLabel = identifier.Length > 0 ? $"{identifier}" : "";
        SceneManager.LoadScene($"C{chapter}S{scene}{subLabel}");
    }
}
