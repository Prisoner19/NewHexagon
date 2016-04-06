using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ObjectMovement : MonoBehaviour {

	public bool isAmmo;

	private float speed = 100;
	private float object_width, object_height;
	private float player_width, player_height;

	// Use this for initialization
	void Start () 
	{
		object_width = this.gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		object_height = this.gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;

		player_width = Controller.Instance.playerTransf.gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		player_height = Controller.Instance.playerTransf.gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Move ();
	}

	void FixedUpdate()
	{
		bool isColliding = Check_For_Collision ();

		if (isColliding) 
		{
			if (isAmmo)
			{
				Controller.Instance.player_inventory.Increase_Ammo (6);
				Destroy (this.gameObject);
			}
			else
			{
				CameraShake.Instance.Big_Shake ();
				//SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
		}
	}

	private void Move()
	{
		transform.position = Vector3.MoveTowards (transform.position, Vector3.zero, speed * Controller.Instance.speedFactor * Time.deltaTime);
        Debug.Log("" + speed);
	}

	private bool Check_For_Collision()
	{
		Vector3 playerPos = Controller.Instance.playerTransf.position;

		float horDis = Mathf.Abs (playerPos.x - gameObject.transform.position.x);
		float verDis = Mathf.Abs (playerPos.y - gameObject.transform.position.y);

		if(horDis < (object_width/2 + player_width/2))
		{
			if (verDis < (object_height / 2 + player_height / 2)) 
			{
				return true;
			}
		}

		return false;
	}

	public float Speed 
	{
		get { return speed; }
		set { speed = value; }
	}
}
