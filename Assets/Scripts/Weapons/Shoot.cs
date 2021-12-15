﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	public Transform gun;
	Vector2 direction;

	public GameObject bullet;

	public float bulletSpeed;

	public Transform shootPoint;

	public float fireRate;

	public float bulletsRemaining = 1000;

	float nextShot;

	public RobotController player;

	Animation anim;

    // Start is called before the first frame update
    void Start()
    {
		anim = 	gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
		Vector2 pos = Camera.main.ScreenToWorldPoint(gameObject.transform.position);
		direction = pos - (Vector2)gun.position;

		if (Input.GetButtonDown("Fire1") && bulletsRemaining > 0) {
			if(Time.time > nextShot){
				nextShot = Time.time + 1 / fireRate;
				Fire();
			}
		}
    }

	void Fire(){
		bool isFacingLeft = player.facingLeft;
		bulletsRemaining--;
		GameObject bulletInstance = Instantiate(bullet, shootPoint.position, shootPoint.rotation);

		if(!isFacingLeft) {
			Vector3 theScale = bullet.transform.localScale;
			theScale.x *= -1;
			bulletInstance.transform.localScale = theScale;
		}

		bulletInstance.GetComponent<Rigidbody2D>().AddForce(bulletInstance.transform.right * bulletSpeed * (isFacingLeft ? 1 : -1));
		Destroy(bulletInstance, 3);
	}
}
