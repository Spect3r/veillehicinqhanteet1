using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Spider : Insect {

	public bool isEnemy(GameObject enemy){
		if (enemy.tag == "Spider" || enemy.tag == "Termite")
			return true;
		else
			return false;
	}

	/*void attack(Insect target){
		target.life -= this.strength;
	}*/


}
