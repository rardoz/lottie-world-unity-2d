using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointPopUp : MonoBehaviour
{

    private bool isCoroutineExecuting = false;
    public float clearDelay = 1.0f;
    Text label;

    IEnumerator enumerator;
    public void Start()
    {
        label = GetComponent<Text>();
        label.text = "";
    }
    public void ShowPoints(int points)
    {
        if (enumerator != null)
        {
            StopCoroutine(enumerator);
            gameObject.GetComponent<Animation>().Rewind();
            gameObject.GetComponent<Animation>().Play();
            enumerator = null;
        }
        label = label ? label : GetComponent<Text>();
        label.text = (points > 0 ? "+" : "-") + points;

        enumerator = ExecuteAfterTime(clearDelay);
        StartCoroutine(enumerator);
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
        GetComponent<GameObject>().SetActive(false);
    }
}
