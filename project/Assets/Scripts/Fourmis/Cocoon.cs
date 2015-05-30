using UnityEngine;
using System.Collections;

public class Cocoon : MonoBehaviour {

	public GameObject worker;
	public GameObject soldier;
	public GameObject nurse;

	// Use this for initialization
	void Start () {
		Invoke ("born", 10);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void born(){
		int number = Random.Range (0, 2);
		switch (number) {
		case 0:
			Debug.Log ("A worker is born");
			Instantiate (worker, this.transform.position, this.transform.rotation);
			Destroy(gameObject);
			break;
		case 1:
			Debug.Log ("A soldier is born");
			Instantiate (soldier, this.transform.position, this.transform.rotation);
			Destroy(gameObject);
			break;
		case 2:
			Debug.Log ("A nurse is born");
			Instantiate (nurse, this.transform.position, this.transform.rotation);
			Destroy(gameObject);
			break;
		}
	}
}
