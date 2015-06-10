using UnityEngine;
using System.Collections;

public class Warehouse : MonoBehaviour {

	private int foodQuantity = 0;

	public void addFood()
	{
		foodQuantity++;
		
		//Debug.Log (foodQuantity);
	}

	public int getFoodQuantity()
	{
		return this.foodQuantity;
	}

	public void setFoodQuantity(int foodQuantity)
	{
		this.foodQuantity += foodQuantity;
	}
	
}
