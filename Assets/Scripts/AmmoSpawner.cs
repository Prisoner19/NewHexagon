using UnityEngine;
using System.Collections;

public class AmmoSpawner : MonoBehaviour 
{
	public GameObject pfb_ammo;

	public void Spawn_Ammo()
	{
		bool horizontal =  (0.5 > Random.Range (0, 1.0f)) ? true : false;
		float dir = (0.5 > Random.Range (0, 1.0f)) ? 1 : -1;

		GameObject go_ammo = GameObject.Instantiate (pfb_ammo);

		if (horizontal) 
		{
			go_ammo.transform.position = new Vector3 (6 * dir, 0);
		} 
		else 
		{
			go_ammo.transform.position = new Vector3 (0, 6 * dir);
		}
	}
}
