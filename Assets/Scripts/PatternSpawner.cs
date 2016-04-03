using UnityEngine;
using System.Collections;
using SimpleJSON;

public class PatternSpawner : MonoBehaviour {

	public TextAsset jsonFile;
	public GameObject pfb_enemy;
	public GameObject pfb_ammo;

	private JSONNode jsonData;

	private const int _WAIT_TIME = 0;
	private const int _TYPE = 1;
	private const int _DIR = 2;
	private const int _SPEED = 3;

	private int last_pattern = 0;

	// Use this for initialization
	void Start () 
	{
		jsonData = JSON.Parse (jsonFile.text);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Spawn_New_Pattern()
	{
		int rand_pattern;

		do
		{
			rand_pattern = Random.Range (1, 4);
		} 
		while(rand_pattern == last_pattern);

		last_pattern = rand_pattern;

		StartCoroutine (Start_Pattern_Spawning (rand_pattern + ""));
	}

	private IEnumerator Start_Pattern_Spawning(string patternID)
	{
		for (int i = 0; i < jsonData [patternID].Count; i++)
		{
			yield return new WaitForSeconds (jsonData[patternID][i][_WAIT_TIME].AsFloat / Controller.Instance.speedFactor);

			Spawn_Object (jsonData [patternID] [i] [_TYPE].Value, jsonData [patternID] [i] [_DIR].Value, jsonData [patternID] [i] [_SPEED].AsFloat);
		}

		yield return new WaitForSeconds (0.5f);

		Controller.Instance.sprRnd_bg.color = new Color (Random.Range (0, 1f), Random.Range (0, 1f), Random.Range (0, 1.0f));

		Spawn_New_Pattern ();
	}

	private void Spawn_Object(string type, string dir, float speed)
	{
		GameObject go_object = null;

		if(type == "ammo")
		{
			go_object = GameObject.Instantiate (pfb_ammo);
		}
		else if(type == "enemy")
		{
			go_object = GameObject.Instantiate (pfb_enemy);
		}

		switch (dir)
		{
		    case "left": go_object.transform.position =  new Vector3 (-36, 0);
			break;

		    case "up": go_object.transform.position =  new Vector3 (0, 36);
			break;

		    case "right": go_object.transform.position =  new Vector3 (36, 0);
			break;

		    case "down": go_object.transform.position =  new Vector3 (0, -36);
			break;
		}

		if (go_object != null)
		{
			go_object.GetComponent<ObjectMovement> ().Speed = speed;
		}
	}
}
