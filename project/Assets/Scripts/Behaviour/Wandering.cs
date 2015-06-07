using UnityEngine;
using System.Collections;

public class Wandering {
	
	public float rotationSpeed = 10;
	public float movementSpeed = 10;
	public float rotationTime = 2;
	
	/*void Start()
	{
		Invoke("ChangeRotation",rotationTime);
	}
	
	void ChangeRotation()
	{
		if(Random.value > 0.5f)
		{
			rotationSpeed = -rotationSpeed;
		}
		Invoke("ChangeRotation",rotationTime);
	}
	
	
	void Update() {
		
		transform.Rotate (new Vector3 (0, 0, rotationSpeed * Time.deltaTime));
		//transform.position += transform.up*movementSpeed*Time.deltaTime;
		rigidbody2D.velocity = Vector2.up*movementSpeed*Time.deltaTime;


		
	}*/

	public Vector2 run(GameObject source)
	{
		Vector2 referenceForward = new Vector2(-1,0);	
		Vector2 directionFromRotation = source.transform.rotation * referenceForward;
		
		Vector2 newDirection = Quaternion.AngleAxis(Random.Range(0f,10f)-Random.Range(0f,10f), source.transform.forward) * directionFromRotation; 
		
		return newDirection;
	}

}