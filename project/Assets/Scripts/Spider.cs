using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spider : AbstractAgent {

	private int strength = 4;
	private int speed = 10;
	private int life = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool isEnemy(GameObject enemy){
		if (enemy.tag == "Spider" || enemy.tag == "Termite")
			return true;
		else
			return false;
	}

	void attack(Insect target){
		target.life -= this.strength;
	}


}
