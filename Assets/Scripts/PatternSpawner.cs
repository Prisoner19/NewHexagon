using UnityEngine;
using System.Collections;
using SimpleJSON;
using Controller;

public class PatternSpawner : MonoBehaviour {

	public TextAsset jsonFile;
	public GameObject pfb_mover;

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

		// do
		// {
		// 	rand_pattern = Random.Range (1, 4);
		// } 
		// while(rand_pattern == last_pattern);

		// last_pattern = rand_pattern;

		StartCoroutine (Start_Pattern_Spawning (1 + ""));
	}

	private IEnumerator Start_Pattern_Spawning(string patternID)
	{
        yield return new WaitForSeconds (1f);
        
        Background_C.Instance.Change_Color();
        
		for (int i = 0; i < jsonData [patternID].Count; i++)
		{
			yield return new WaitForSeconds (jsonData[patternID][i][_WAIT_TIME].AsFloat / Game_C.Instance.speedFactor);

			Spawn_Mover (jsonData [patternID] [i] [_TYPE].Value, jsonData [patternID] [i] [_DIR].Value, jsonData [patternID] [i] [_SPEED].AsFloat);
		}
        
        yield return new WaitForSeconds (1f);
        
		Spawn_New_Pattern ();
	}

	private void Spawn_Mover(string type, string dir, float speed)
	{
        GameObject go_object = GameObject.Instantiate (pfb_mover);
        go_object.GetComponent<Mover.Model>().Initialize(Helper.String_To_MoverType(type), dir, speed);
	}
}
