﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public float midRotation;
	public float deltaRotation;

	void OnMouseDrag() {

		Vector3 parentScreenPosition = Camera.main.WorldToScreenPoint(transform.parent.position);
		Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Vector3 target = new Vector3 (screenPosition.x - parentScreenPosition.x, screenPosition.y - parentScreenPosition.y, 0);
		Quaternion rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), target);

		var rotatedVector = Quaternion.Euler (0, 0, midRotation) * Vector3.up;	// local
		var rotatedVector2 = transform.parent.localRotation * Vector3.up;		// local
		float angle = Vector3.Angle(rotatedVector, rotatedVector2);

		transform.parent.rotation = rotation;
		if (angle > deltaRotation) {
			transform.parent.localRotation = Quaternion.Euler (0, 0, midRotation + deltaRotation);
		}

		Debug.Log (rotatedVector + ", " + rotatedVector2 + ", " + angle);

//		Vector3 fromVector = new Vector3(0, 0, midRotation)
//		if (midRotation, )

//		Debug.Log (transform.parent.localEulerAngles.z);

//		if (WrapAngle(transform.parent.localEulerAngles.z - midRotation) > deltaRotation) {
//			transform.parent.transform.localRotation = Quaternion.Euler (transform.parent.transform.localEulerAngles.x,
//			transform.parent.transform.localEulerAngles.y,
//			UnwrapAngle(midRotation + deltaRotation));
//		} else if (WrapAngle(transform.parent.localEulerAngles.z - midRotation) < -deltaRotation) {
//					transform.parent.transform.localRotation = Quaternion.Euler (transform.parent.transform.localEulerAngles.x,
//						transform.parent.transform.localEulerAngles.y,
//						UnwrapAngle(midRotation - deltaRotation));
//				}
	}

	float WrapAngle(float angle) {
		angle %= 360;
		if (angle > 180)
			return angle - 360;
		return angle;
	}

	float UnwrapAngle (float angle){
		if(angle >=0)
			return angle;
		angle = -angle%360;
		return 360-angle;
	}
}
