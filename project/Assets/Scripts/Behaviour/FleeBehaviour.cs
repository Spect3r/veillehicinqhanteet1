using UnityEngine;
using System.Collections;

public class FleeBehaviour {

	public Vector2 run(GameObject source, GameObject target)
	{
		Vector2 direction = source.transform.position - target.transform.position;
		
		return direction.normalized;
	}
}
