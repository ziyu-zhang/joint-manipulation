﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour {
	
    void OnCollisionEnter(Collision col) {
		Debug.Log (col.gameObject);
		Debug.Break ();
    }
}
