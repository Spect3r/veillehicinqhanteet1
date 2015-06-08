using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AntQueen : Ant {

	private int bornTime = 100;
	private int timer = 0;
	public GameObject cocoon;

	/*// Use this for initialization
	void Start () {
		InvokeRepeating("born",5,bornTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void born(){
		Instantiate (cocoon, this.transform.position, this.transform.rotation);
	}

	Collider2D[] getPerception(){
		Collider2D[] perceptions = Physics2D.OverlapCircleAll(transform.position, 3f);
	}
	
	List<Action> makeDecision(Collider2D[] perceptions){
		List<Action> actions;
		foreach (Collider2D collider in perceptions) {
			if(timer>=bornTime)
			{
				timer+=1;
			}else{
				born ();
				timer = 0;
			}
		}
	}*/
	
	protected override Collider2D[] getPerception(){
		return Physics2D.OverlapCircleAll(this.transform.position, 3f);
	}
	
	protected override List<Action> makeDecision(Collider2D[] perceptions){
		List<Action> actions = new List<Action>();


			if(timer<=bornTime)
			{
				timer+=1;
			}else{
				actions.Add(new Action("born", null));
				timer = 0;
			}
		return actions;
	}
	
	protected override Vector2 applyAction(List<Action> actions) {
		Vector2 direction = new Vector2 (); // = new Vector2 (1f,1f);
		
		foreach(Action action in actions)
		{
			switch(action.getBehaviour())
			{	
			case "seek" :
				direction += this.seekBehaviour.run(this.gameObject, action.getTarget());
				break;
			case "born" :
				this.born();
				break;
			}
		}
		return direction;
	}
	protected override void move(Vector2 direction) {
		
	}


	private void born()
	{
		Instantiate (cocoon, this.transform.position + new Vector3(3,0,0), Quaternion.identity);
	}
}
