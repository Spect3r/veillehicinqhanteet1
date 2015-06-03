using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class GroundSelection : MonoBehaviour {

	public Text text;
	GameObject camera;

	// Use this for initialization
	void Start () {
		//text = transform.FindChild("Text").GetComponent<Text>();
		text.text = "Sous-sol";
		camera = GameObject.FindGameObjectWithTag ("MainCamera");
	
	}
	
	// Update is called once per frame
	void Update () {
		}

	public void ChangeGround(){
		if (text.text == "Sous-sol") {
			text.text = "Sol";
			camera.transform.position = new Vector3(57f,0f,-10f);
		} else {
			text.text = "Sous-sol";	
			camera.transform.position = new Vector3(2.5f, 0f,-10f);
		}
	}
}
