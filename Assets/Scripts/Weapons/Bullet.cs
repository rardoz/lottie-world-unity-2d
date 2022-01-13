using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Awake()
    {
        //Make Collider2D as trigger
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        bool isEnemy = c2d.CompareTag("Enemy");
        bool isAssistant = c2d.CompareTag("ShadyCameraAssistant");
        if (isEnemy)
        {
            Destroy(gameObject, 0.1f);
            Destroy(c2d.gameObject);
        }
        else if (isAssistant)
        {
            c2d.gameObject.GetComponent<ShadyAssistant>().blinker.startBlinking = true;
        }
    }
}
