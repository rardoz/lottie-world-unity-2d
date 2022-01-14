using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    public Vector2 parallaxEffectMultiplier;
    private Transform cameraTransform;
    Vector3 lastCameraPosition;

    public bool enableY = false;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    private void FixedUpdate()
    {
        //gameObject.GetComponent<Rigidbody2D>().velocity.y
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, enableY ? deltaMovement.y * parallaxEffectMultiplier.y : 0);
        lastCameraPosition = cameraTransform.position;
    }
}
