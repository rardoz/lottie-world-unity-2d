﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : Death
{
    // Start is called before the first frame update
   public override void onDeadlyTriggered(){
		Debug.Log("PIT");
		reloadScene();
	}
}
