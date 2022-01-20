using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyRain : MonoBehaviour
{
    public GameObject MoneyPile;
    void OnTriggerEnter2D(Collider2D c2d)
    {
        if (c2d.gameObject.tag == "Player")
        {
            MoneyPile.SetActive(true);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
