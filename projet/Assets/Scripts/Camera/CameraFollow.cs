﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject toFollow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position =  new Vector3(toFollow.transform.position.x, toFollow.transform.position.y, -10);
	}
}
