using UnityEngine;
using System.Collections;

public class AntFlee : MonoBehaviour {
	
	public float speed = 3f;
	
	Collider2D[] perceptions;
	
	Animator animation;
	
	// Use this for initialization
	void Start () {
		//Physics2D.gravity = new Vector3(0,0,0);
		
		
	}
	
	// Update is called once per frame
	void Update () {
		//Physics2D.OverlapCircleNonAlloc(transform.position, 50f, perception);
		
		/*if ( Physics2D.OverlapCircle(transform.position, 3f) != null)
			Debug.Log ("Ok2");*/
		
		perceptions = Physics2D.OverlapCircleAll(transform.position, 3f);
		
		//if(perceptions.Length != 1) {
		
			Vector3 movement = new Vector3(0f,0f,0f);
			Vector3 direction = new Vector3(0f,0f,0f);
			int count = 0;
			
			foreach (Collider2D collider in perceptions) {
				movement += transform.position - collider.transform.position;
				//movement +=	direction.normalized;
				
				//Debug.Log("pos:"+transform.position+"-pos:"+collider.transform.position);
				//Debug.Log(count + " - " + movement);
				count++;
			}
			
			// Kinematic
			//transform.position += movement * Time.deltaTime;
			rigidbody2D.velocity = movement.normalized * speed;
			
			// Steering
			//rigidbody2D.AddForce(new Vector2(movement.x,movement.y));
			
			
			if(movement.magnitude > 0) {
			
				Vector3 referenceForward = new Vector3(-1,0,0);
				
				float angle = Vector3.Angle(referenceForward, movement);
				
				float sign = Mathf.Sign(Vector3.Dot(new Vector3(0,1,0),movement));
							
				transform.rotation = Quaternion.Euler(new Vector3(0,0,angle * -sign));
			
			}
			
			//Debug.Log("Count : "+count);
		//}
		
		
		animation = gameObject.GetComponent<Animator>();
		
		Debug.Log(movement.magnitude);
		
		if(movement.magnitude > 0 ) {
			animation.SetBool("moving", true);
		}
		else
			animation.SetBool("moving", false);
	}
	
	// A fairer en Steering
}
