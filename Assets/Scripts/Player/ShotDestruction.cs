using UnityEngine;
using System.Collections;

public class ShotDestruction : MonoBehaviour 
{

	void Start () 
	{
	
	}
	
	void Update () 
	{
	
	}

    private void Destroy_Shot()
    {
        Destroy(this.gameObject);
    }
}
