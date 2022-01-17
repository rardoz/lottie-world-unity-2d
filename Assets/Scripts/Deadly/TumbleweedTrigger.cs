using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleweedTrigger : MonoBehaviour
{

    public GameObject TumbleWeedObject;
    void OnTriggerEnter2D(Collider2D c2d)
    {
        if (c2d.gameObject.tag == "Player")
        {
            TumbleWeedObject.SetActive(true);
            Destroy(gameObject, 10f);
        }
    }
}
