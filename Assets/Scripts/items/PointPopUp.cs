using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointPopUp : MonoBehaviour
{

    private bool isCoroutineExecuting = false;
    public float clearDelay = 1.0f;
    Text label;
    public void Start()
    {
        label = GetComponent<Text>();
        label.text = "";
    }
    public void ShowPoints(int points)
    {
        label.text = (points > 0 ? "+" : "-") + points;
        StartCoroutine(ExecuteAfterTime(clearDelay));
    }

    void ClearText()
    {
        GetComponent<Text>().text = "";
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);
        ClearText();
        isCoroutineExecuting = false;
    }
}
