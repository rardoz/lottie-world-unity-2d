﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : Death
{
	// Start is called before the first frame update
	public override void onDeadlyTriggered(Collider2D c2d)
	{
		reloadScene();
	}
}
