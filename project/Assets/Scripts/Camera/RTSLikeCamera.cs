using UnityEngine;
using System.Collections;

public class RTSLikeCamera : MonoBehaviour {

	float distance = 60;
	float sensitivityDistance = 50;
	float damping = 5;
	float minFOV = 3;
	float maxFOV = 55;
	
	// Use this for initialization
	void Start () {
		Screen.showCursor = true;
		distance = camera.fieldOfView;		
	}
	
	// Update is called once per frame
	void Update () {
		
		float mousePosX = Input.mousePosition.x; 
		float mousePosY = Input.mousePosition.y; 
		float scrollDistance = 5f; 
		float scrollSpeed = 40;
		if (Input.GetMouseButton(0))
		{
			if (mousePosX < scrollDistance) //left movement
			{ 
				transform.Translate(Vector3.right * -scrollSpeed * Time.deltaTime);
			} 
			
			if (mousePosX >= Screen.width - scrollDistance) //right movement
			{ 
				transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime); 
			}
			
			if (mousePosY < scrollDistance) //south movement
			{ 
				transform.Translate(transform.up * -scrollSpeed * Time.deltaTime); 
			} 
			
			if (mousePosY >= Screen.height - scrollDistance) //north movement
			{ 
				transform.Translate(transform.up * scrollSpeed * Time.deltaTime); 
			}
		}
		scrollDistance -= (Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime) * scrollSpeed * Mathf.Abs(scrollDistance);

		distance -= Input.GetAxis("Mouse ScrollWheel") * sensitivityDistance;
		distance = Mathf.Clamp(distance, minFOV, maxFOV);
		this.camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, distance, Time.deltaTime * damping);
	}
}
