using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossLifeProgress : MonoBehaviour
{
    public void Reset()
    {
        BossLife.totalLives = BossLife.maxLives;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x <= 0)
        {
            Reset();
        }
        else
        {
            transform.localScale = new Vector2((1.0f * BossLife.totalLives / BossLife.maxLives), transform.localScale.y);
            if (transform.localScale.x > 1)
            {
                transform.localScale = new Vector2(1.0f, transform.localScale.y);
            }
        }
    }
}
