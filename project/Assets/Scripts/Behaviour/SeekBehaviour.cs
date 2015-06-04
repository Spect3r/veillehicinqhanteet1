using UnityEngine;
using System.Collections;

public class SeekBehaviour {

	public Vector2 run(GameObject source, GameObject target)
	{
		Vector2 direction = target.transform.position - source.transform.position;
		
		return direction.normalized;
	}
}