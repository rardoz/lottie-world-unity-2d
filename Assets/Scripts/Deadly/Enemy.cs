using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed = 0.05f;
	public bool hasBeenTriggered = false;

	public Camera mainCamera;
    void Update()
    {
		if(hasBeenTriggered || IsTargetVisible()) {
			hasBeenTriggered = true;
			Vector3 theScale = transform.position;
        	theScale.x -= speed;
        	transform.position = theScale;
		}
    }

	 bool IsTargetVisible()
     {
         var planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
         var point = gameObject.transform.position;
         foreach (var plane in planes)
         {
             if (plane.GetDistanceToPoint(point) < 0)
                 return false;
         }
         return true;
     }

}
