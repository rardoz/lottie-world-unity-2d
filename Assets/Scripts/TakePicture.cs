using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePicture : MonoBehaviour
{
    public Photographer photographer;
    public bool whenFacingLeft;

    public Polaroid polaroid;
    void Awake()
    {
        //Make Collider2D as trigger
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        if (c2d.CompareTag("Photographer") && photographer.player.facingLeft == whenFacingLeft)
        {
            photographer.OnTakePhoto();
            GameObject renderer = polaroid.gameObject;
            renderer.SetActive(true);
            GetComponent<Collider2D>().enabled = false;
            polaroid.itemEnabled = true;
        }
    }
}
