using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

	private int current_ammo = 6;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Decrease_Ammo()
	{
		current_ammo = (current_ammo > 0) ? current_ammo - 1 : 0;
	}

	public void Increase_Ammo(int additional_ammo)
	{
		current_ammo += additional_ammo;
	}

	public bool Check_Ammo()
	{
		return (current_ammo > 0);
	}

	public int Current_ammo {
		get { return current_ammo; }
	}
}
