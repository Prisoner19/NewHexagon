using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour 
{
	public GameObject pfb_enemy;

	public void Spawn_Enemy()
	{
		bool horizontal =  (0.5 > Random.Range (0, 1.0f)) ? true : false;
		float dir = (0.5 > Random.Range (0, 1.0f)) ? 1 : -1;

		GameObject go_enemy = GameObject.Instantiate (pfb_enemy);

		if (horizontal) 
		{
			go_enemy.transform.position = new Vector3 (36 * dir, 0);
		} 
		else 
		{
			go_enemy.transform.position = new Vector3 (0, 36 * dir);
		}
        
        // Debug.Log('' + gameObject.transform.position);
        Debug.Log("asd");
	}
}
