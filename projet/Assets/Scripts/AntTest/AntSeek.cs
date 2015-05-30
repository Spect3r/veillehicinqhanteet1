using UnityEngine;
using System.Collections;

public class AntSeek : MonoBehaviour {

	Collider2D perception;
	
	// Update is called once per frame
	void Update () {
	
		perception = Physics2D.OverlapCircle(transform.position, 3f);
		
		if(perception != null) {
			transform.position += (perception.transform.position - transform.position) * Time.deltaTime;
		}
	}
}
