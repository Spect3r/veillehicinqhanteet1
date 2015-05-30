using UnityEngine;
using System.Collections;

public class AntController : MonoBehaviour {

	public float speed ;
	public float rotationSpeed;
	//transform
	Transform myTrans;
	//object position
	Vector3 myPos;
	//object rotation
	Vector3 myRot;
	//object rotation 
	float angle;
	
	
	
	
	Animator animation;
	
	// Use this for initialization
	void Start ()
	{
		myTrans = transform;
		myPos = myTrans.position;
		myRot = myTrans.rotation.eulerAngles;
		
		
		animation = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
		/*if(Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0 ) {
			animation.SetBool("moving", true);
		}
		else
			animation.SetBool("moving", false);*/
			
		//rigidbody2D.velocity = new Vector2(-Input.GetAxis("Vertical")*3, 0f);
		
		//rigidbody2D.AddRelativeForce(new Vector2(-Input.GetAxis("Vertical")*3, 0f));
		
		//rigidbody2D.rotation = rigidbody2D.rotation - Input.GetAxis("Horizontal");	
		
		
		//gameObject.transform.Rotate(Vector3.left * Time.deltaTime * Input.GetAxis("Horizontal"));
		
		//gameObject.transform.localPosition += gameObject.transform.forward * -Input.GetAxis("Vertical")*10 * Time.deltaTime;
		
		//transform.Rotate(0f, 0f, Input.GetAxis("Horizontal") * Time.deltaTime);
		
		
		//transform.localEulerAngles += new Vector3(0f, 0f, -Input.GetAxis("Horizontal")*10) * Time.deltaTime;
		//transform.Rotate(Vector3.up * Time.deltaTime);
		//transform.Translate(Input.GetAxis("Vertical") * Time.deltaTime, 0f, 0f);
		
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		
		//converting the object euler angle's magnitude from to Radians    
		angle = myTrans.eulerAngles.magnitude * Mathf.Deg2Rad;
		
		
		//rotate object Right & Left
		if (Input.GetKey (KeyCode.RightArrow)) {
			myRot.z -= rotationSpeed;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			myRot.z += rotationSpeed;
		}
		
		
		//move object Forward & Backward
		if (Input.GetKey (KeyCode.UpArrow)) {
			
			myPos.x -= (Mathf.Cos (angle) * speed) * Time.deltaTime;
			myPos.y -= (Mathf.Sin (angle) * speed) * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			myPos.x += Mathf.Cos (angle) * Time.deltaTime;
			myPos.y += Mathf.Sin (angle) * Time.deltaTime;    
		}
		
		
		//Apply
		myTrans.position = myPos;
		myTrans.rotation = Quaternion.Euler (myRot);
		
	}
}